
var focusedGrid = null;

vdcGrid.prototype.convertToExcel = function (columnTypes, excelDataHiddenID, excelDeletedIds) {
    this.ExcelColumnTypes = columnTypes;
    this.ExcelDataContainer = document.getElementById(excelDataHiddenID);
    this.ExcelDeletedIdsContainer = document.getElementById(excelDeletedIds);

    this.ExcelDataContainer.value = '';
    this.ExcelDeletedIdsContainer.value = '';

    this._lastEditedField = null;
    this._lastEditedFieldEditor = null;
    this._editorid = null;
    this._keyNavigationIsEnabled = false;
    this._lastEditedFieldEditorValue = null;
}


vdcGrid.prototype.addNewRow = function () {
    this.addRecord();
    this.insertTemporaryRecord(false, true);

    var row = this.GridBodyContainer.firstChild.firstChild.childNodes[1].lastChild;
    var firstVisibleColumnIndex = -1;

    var tempThis = this;
    for (var i = 0; i < this.ColumnsCollection.length; i++) {

        if (this.ExcelColumnTypes[i] != 'Actions') {
            var textBox = document.createElement('INPUT');
            textBox.type = 'text';
            textBox.name = 'TextBox1';
            textBox.className = 'excel-textbox';
            textBox.readOnly = true;
            row.cells[i].firstChild.firstChild.appendChild(textBox);
        }
        switch (this.ExcelColumnTypes[i]) {

            case 'TextBox':
                textBox.onfocus = function () { tempThis.editWithTextBox(this); };
                break;

            case 'MultiLineTextBox':
                textBox.onfocus = function () { tempThis.editWithMultiLineTextBox(this); };
                break;

            case 'DropDownList':
                textBox.onfocus = function () { tempThis.editWithComboBox(this); };
                break;
            case 'CheckBox':
                textBox.onfocus = function () { tempThis.editWithCheckBox(this); };
                break;

            case 'Actions':
                var deleteLink = document.createElement('A');
                deleteLink.href = 'javascript: //';
                deleteLink.onclick = function () { tempThis.removeRow(this); };
                row.cells[i].firstChild.firstChild.appendChild(deleteLink);

                var deleteLinkImg = document.createElement('IMG');
                deleteLinkImg.src = 'resources/images/Delete.png';
                deleteLinkImg.alt = 'Delete';
                deleteLinkImg.title = 'Delete';
                deleteLinkImg.height = 21;
                deleteLinkImg.border = 0;
                deleteLink.appendChild(deleteLinkImg);

                break;
        }

        if (firstVisibleColumnIndex == -1 && this.ColumnsCollection[i].Visible) {
            firstVisibleColumnIndex = i;
        }
    }

    var textBoxToFocus = row.cells[firstVisibleColumnIndex].firstChild.firstChild.firstChild;

    window.setTimeout(function () { textBoxToFocus.focus(); }, 250);

    return false;
}



vdcGrid.prototype.removeRow = function (link) {
    while (link.nodeName != 'TR') {
        link = link.parentNode;
    }

    link.parentNode.removeChild(link);

    if (this.ExcelDeletedIdsContainer.value != '') {
        this.ExcelDeletedIdsContainer.value += ',';
    }
    var textboxes = link.firstChild.firstChild.getElementsByTagName('INPUT');
    this.ExcelDeletedIdsContainer.value += textboxes[0].value;
}



vdcGrid.prototype.saveExcelChanges = function (excelDataHiddenID) {
    var excelData = new Array();
    var rowsContainer = this.GridBodyContainer.firstChild.firstChild.childNodes[1];
    for (var i = 0; i < rowsContainer.childNodes.length; i++) {
        var row = rowsContainer.childNodes[i];
        var rowData = new Array();
        for (var j = 0; j < row.childNodes.length; j++) {
            var textboxes = row.childNodes[j].firstChild.firstChild.getElementsByTagName('INPUT');
            rowData.push(textboxes[0].value);
        }
        excelData.push(rowData.join('|*cell*|'));
    }
    if (!this.ExcelDataContainer) {

        // this.ExcelDataContainer = document.getElementById('ContentPlaceHolder1_gridNamKeHoachExcelData'); 
        this.ExcelDataContainer = document.getElementById(excelDataHiddenID);
    }
    this.ExcelDataContainer.value = excelData.join('|*row*|');

    return true;
}
vdcGrid.prototype.saveExcelNhaThauChanges = function (excelDataHiddenID) {
    var excelData = new Array();
    var rowsContainer = this.GridBodyContainer.firstChild.firstChild.childNodes[1];
    for (var i = 0; i < rowsContainer.childNodes.length; i++) {
        var row = rowsContainer.childNodes[i];
        var rowData = new Array();
        for (var j = 0; j < row.childNodes.length; j++) {
            if (j != 2) {
                var textboxes = row.childNodes[j].firstChild.firstChild.getElementsByTagName('INPUT');
                rowData.push(textboxes[0].value);
            }
        }
        excelData.push(rowData.join('|*cell*|'));
    }
    if (!this.ExcelDataContainer) {
        this.ExcelDataContainer = document.getElementById(excelDataHiddenID);
    }
    this.ExcelDataContainer.value = excelData.join('|*row*|');

    return true;
}



//function ComboBox_Open(sender) {
//    focusedGrid._keyNavigationIsEnabled = false;
//}

vdcGrid.prototype.editWithTextBox = function (textbox) {
    this.editCell(textbox, 'TextBoxEditor');
}

vdcGrid.prototype.editWithMultiLineTextBox = function (textbox) {
    this.editCell(textbox, 'MultiLineTextBoxEditor');
}

vdcGrid.prototype.editWithComboBox = function (textbox) {
    this.editCell(textbox, 'ComboBoxEditor');
}
vdcGrid.prototype.editWithCheckBox = function (textbox) {
    this.editCell(textbox, 'CheckBoxEditor');
}

vdcGrid.prototype.editWithDatePicker = function (textbox) {
    this.editCell(textbox, 'DatePickerEditor');
}

vdcGrid.prototype.editCell = function (textbox, editorId) {
    focusedGrid = this;
    if (this._lastEditedField != null) {
        if (this._lastEditedFieldEditor.type == 'text' || this._lastEditedFieldEditor.type == 'textarea') {
            this._lastEditedField.value = this._lastEditedFieldEditor.value;
        } else {
            this._lastEditedField.value = this._lastEditedFieldEditor.checked ? 'yes' : 'no';
        }
        document.getElementById('FieldEditorsContainer').appendChild(document.getElementById(this._editorid + 'Container'));
        this._lastEditedField.style.display = '';
    }
    textbox.style.display = 'none';
    var abc = document.getElementById(editorId + 'Container');
    textbox.parentNode.appendChild(abc);
    var hindden_editor = null;
    var editor = null;
    if (editorId == 'ComboBoxEditor') {
        editor = $("input[id$='TB']")[0];
    }
    else if (editorId == "CheckBoxEditor") {
        editor = $("input[id$='CheckBoxEditor']")[0];
    }
    else {
        editor = document.getElementById(this.UniqueID.replace(this.ID, "") + editorId);
        editor.onblur = persistFieldValue;  
    }
    var typee = editor.type;
    if (typee == 'text' || typee == 'textarea') {
        editor.value = textbox.value;
        this._lastEditedFieldEditorValue = editor.value;
    } else {
        editor.checked = (textbox.value == 'yes');
        this._lastEditedFieldEditorValue = editor.checked;
    }
    editor.focus();
    this._lastEditedField = textbox;
    this._editorid = editorId;
    this._lastEditedFieldEditor = editor;
    this._keyNavigationIsEnabled = true;
    var tempThis = this;
    window.setTimeout(function () { tempThis.selectLastFieldEditor(); }, 150);
}

vdcGrid.prototype.selectLastFieldEditor = function () {
    //    if (this._lastEditedFieldEditor) {
    //        var _type = this._lastEditedFieldEditor.type;
    //        if (_type == 'text' || _type == 'textarea') {
    //            this._lastEditedFieldEditor.select();
    //        } else if (typeof (this._lastEditedFieldEditor._dropDownList) != 'undefined') {
    //            this._lastEditedFieldEditor._dropDownList.TextBox.select();
    //        }
    //    }
}

//function persistFieldValue(field) {
//    if (focusedGrid != null && focusedGrid._lastEditedField != null) {
//        if (focusedGrid._lastEditedFieldEditor.type == 'text' || focusedGrid._lastEditedFieldEditor.type == 'textarea') {
//            focusedGrid._lastEditedField.value = focusedGrid._lastEditedFieldEditor.value;
//        } else {
//            focusedGrid._lastEditedField.value = focusedGrid._lastEditedFieldEditor.checked ? 'yes' : 'no';

//        }
//        var a = document.getElementById(focusedGrid._editorid + 'Container');
//        var b = document.getElementById('FieldEditorsContainer');
//        b.appendChild(a);
//        focusedGrid._lastEditedField.style.display = '';

//        focusedGrid._lastEditedField = null;
//        focusedGrid._lastEditedFieldEditor = null;
//    }
//}


vdcGrid.prototype.restoreEditorValue = function () {
    if (this._lastEditedFieldEditor.type == 'text') {
        this._lastEditedFieldEditor.value = this._lastEditedFieldEditorValue;
    } else {
        this._lastEditedFieldEditor.checked = this._lastEditedFieldEditorValue;
    }
    this._lastEditedFieldEditorValue = null;
}



//function navigateThroughCells(sender, key, forced) {
//    if (forced && focusedGrid != null) {
//        focusedGrid._keyNavigationIsEnabled = true;
//    }

//    if (focusedGrid._keyNavigationIsEnabled || forced) {
//        var currentCell = focusedGrid._lastEditedField.parentNode.parentNode.parentNode;
//        var currentCellIndex = 0;
//        var tempCell = currentCell.previousSibling;
//        while (tempCell) {
//            currentCellIndex++;
//            tempCell = tempCell.previousSibling;
//        }
//        var newCell = null;
//        switch (key) {
//            case 37:
//                if (currentCell.previousSibling) {
//                    newCell = currentCell.previousSibling;
//                }
//                break;
//            case 38:
//                if (currentCell.parentNode.previousSibling) {
//                    newCell = currentCell.parentNode.previousSibling.childNodes[currentCellIndex];
//                }
//                break;
//            case 39:
//                if (currentCell.nextSibling) {
//                    newCell = currentCell.nextSibling;
//                }
//                break;
//            case 40:
//                if (currentCell.parentNode.nextSibling) {
//                    newCell = currentCell.parentNode.nextSibling.childNodes[currentCellIndex];
//                }
//                break;
//            default:
//                focusedGrid._keyNavigationIsEnabled = false;
//                if (key == 13 || key == 27 || key == 113) {
//                    if (focusedGrid._lastEditedFieldEditor.type == 'text' || focusedGrid._lastEditedFieldEditor.type == 'textarea') {
//                        var previousValue = focusedGrid._lastEditedFieldEditor.value;
//                        focusedGrid._lastEditedFieldEditor.value = '';
//                        focusedGrid._lastEditedFieldEditor.value = previousValue;
//                    }
//                }
//                break;
//        }

//        if (newCell) {
//            var textboxes = newCell.firstChild.firstChild.getElementsByTagName('INPUT');
//            if (textboxes.length) {
//                textboxes[0].focus();
//            }
//        }
//    } else {
//        if (key == 13 || key == 27) {
//            focusedGrid._keyNavigationIsEnabled = true;
//            focusedGrid.selectLastFieldEditor();

//            if (key == 13) {
//                if (focusedGrid._lastEditedFieldEditor.type == 'text' || focusedGrid._lastEditedFieldEditor.type == 'textarea') {
//                    focusedGrid._lastEditedFieldEditorValue = focusedGrid._lastEditedFieldEditor.value;
//                } else {
//                    focusedGrid._lastEditedFieldEditorValue = focusedGrid._lastEditedFieldEditor.checked();
//                }
//            } else if (focusedGrid != null && focusedGrid._lastEditedFieldEditorValue != null) {
//                window.setTimeout(function () { focusedGrid.restoreEditorValue(); }, 10);
//            }
//        }
//    }

//    if (key == 13 || key == 27) {
//        return false;
//    }

//    return true;
//}


function checkKeydown(sender, key) {
    debugger;
    if (key == 13 || key == 27) {
        return false;
    }
    return true;
}




// Override internal methods

Vdc.Interface.VdcTextBox.prototype.applyCrossBrowserFixes = function () {
}

Vdc.Interface.VdcTextBox.prototype._attachEventHandlers = Vdc.Interface.VdcTextBox.prototype.attachEventHandlers;
Vdc.Interface.VdcTextBox.prototype.attachEventHandlers = function () {
    this._attachEventHandlers();

    if (this.ID.indexOf('DatePicker') == -1) {
        var _blurHandler = this.TextBox.onblur;
        var _tempThis = this;
        this.TextBox.onblur = function () {
            _blurHandler();
            persistFieldValue(this.ID);
        }
    }
}

Vdc.Interface.VdcTextBox.prototype._focus = Vdc.Interface.VdcTextBox.prototype.focus;
Vdc.Interface.VdcTextBox.prototype.focus = function () {
    this._focus();

    if (this.IsActive && focusedGrid != null) {
        focusedGrid._keyNavigationIsEnabled = false;
    }
}

Vdc.Interface.VdcDropDownList.prototype._handleTextKeyPress = Vdc.Interface.VdcDropDownList.prototype.handleTextKeyPress;
Vdc.Interface.VdcDropDownList.prototype.handleTextKeyPress = function (e) {
    //this._handleTextKeyPress(e);
    var keyPressed = Vdc.Interface.VdcCore.getKeyPressed(e);
    navigateThroughCells(this, keyPressed);
}

//Vdc.Interface.VdcButton.prototype._handleTextKeyPress = Vdc.Interface.VdcButton.prototype.handleTextKeyPress;
//Vdc.Interface.VdcButton.prototype.handleTextKeyPress = function (e) {
//    //this._handleTextKeyPress(e);
//    debugger;
//    var keyPressed = Vdc.Interface.VdcCore.getKeyPressed(e);
//    checkKeydown(this, keyPressed);
//}

Vdc.ComboBox.prototype.__handleKeyDown = Vdc.ComboBox.prototype._handleKeyDown;
Vdc.ComboBox.prototype._handleKeyDown = function (e) {
    var keyPressed = Vdc.Interface.VdcCore.getKeyPressed(e);
    navigateThroughCells(this, keyPressed);
    //    if ((keyPressed != 37 && keyPressed != 38 && keyPressed != 39 && keyPressed != 40) || !focusedGrid._keyNavigationIsEnabled) {
    //        this.__handleKeyDown(e);

    //        if (focusedGrid._keyNavigationIsEnabled || keyPressed != 13) {
    //            if (focusedGrid._keyNavigationIsEnabled) {
    //                this.open();
    //            }
    //            focusedGrid._keyNavigationIsEnabled = false;
    //        } else {
    //            focusedGrid._keyNavigationIsEnabled = true;
    //        }

    //        if (keyPressed == 13) {
    //            return false;
    //        }
    //    } else {
    //        navigateThroughCells(this, keyPressed);
    //    }

    //   return true;
}


//Vdc.Interface.VdcCheckBox.prototype._attachEventHandlers = Vdc.Interface.VdcCheckBox.prototype.attachEventHandlers;
//Vdc.Interface.VdcCheckBox.prototype.attachEventHandlers = function () {
//    this._attachEventHandlers();

//        this.CheckBox.onkeydown = function (e) { navigateThroughCells(this, Vdc.Interface.VdcCore.getKeyPressed(e), true); return false; };
//}

//Vdc.Interface.VdcCheckBox.prototype.__handleKeyDown = Vdc.Interface.VdcCheckBox.prototype._handleKeyDown;
//Vdc.Interface.VdcCheckBox.prototype._handleKeyDown = function (e) {
//    var keyPressed = Vdc.Interface.VdcCore.getKeyPressed(e);
//    navigateThroughCells(this, keyPressed);
//}
