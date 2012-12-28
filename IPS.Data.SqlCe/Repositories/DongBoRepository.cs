using IPS.Data.SqlCe.Initializers;
using IPS.Model;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitSettingLibrary;

namespace IPS.Data.SqlCe.Repositories
{
    public class DongBoRepository : IDongBoDataTier
    {

        private OracleConnection _connectGs;
        private OracleConnection _connectDt;
        private OracleDataAdapter _oracleAdapter;
        private OracleCommand _oracleCommand;
        private OracleTransaction _oracleTransaction;

        // dung de xac dinh cau lenh sql cuoi cung. Khi phan bat bug hoan chinh se bo
        private string _lastSql = "";

        #region IDongBoDBServices Members

        public ChangeResultSettings DongBoDBDauTu()
        {
            var result = new ChangeResultSettings();
            // dung de xac dinh bang thuc hien sql cuoi cung. Khi phan bat bug hoan chinh se bo
            var lastTableName = "";
            try
            {
                // tao ket noi dau tu, giam sat                
                ConnectDB.CloseConnection(_connectDt);
                _connectDt = new OracleConnection();
                _connectDt = ConnectDB.GetOracleConnection(_connectDt, NameDatabase.DauTu);

                ConnectDB.CloseConnection(_connectGs);
                _connectGs = new OracleConnection();
                _connectGs = ConnectDB.GetOracleConnection(_connectGs);

                //todo: tao transaction
                //_oracleTransaction = _connectGs.BeginTransaction(IsolationLevel.ReadCommitted);                

                #region bang co lich su

                #region comment for test BangDauTuCoLichSu

                List<string> listColumnId;
                DataTable tableDt;
                DataTable tableGs;
                foreach (var item in Enum.GetNames(typeof (BangDauTuCoLichSu)))
                {
                    lastTableName = "<br /> begin " + item;
                    // list cac cot la khoa chinh cua bang
                    listColumnId = new List<string>();
                    listColumnId.Add("MA_DVI");
                    switch (item)
                    {
                        case "BDT_QLDT_KHDT_TR":
                            listColumnId.Add("NAM");
                            listColumnId.Add("SO_ID");
                            listColumnId.Add("DOT");
                            listColumnId.Add("SO_QD");
                            break;
                        case "BDT_QLDT_QDDT_TINH":
                            listColumnId.Add("SO_ID");
                            listColumnId.Add("BT");
                            break;
                        default:
                            listColumnId.Add("SO_ID");
                            break;
                    }

                    // sql get list unique cua 1 ban ghi                    
                    var sqlDt = "select ";
                    foreach (var dk in listColumnId)
                    {
                        sqlDt += " a." + dk + ", ";
                    }
                    sqlDt += " nvl(max(b.lan),0) lan from " + item + @" a
                        left join " +
                             item + @"_ls b on ";
                    var first = true;
                    foreach (var dk in listColumnId)
                    {
                        if (first)
                        {
                            sqlDt += " a." + dk + " = b." + dk;
                            first = false;
                        }
                        else
                            sqlDt += " and a." + dk + " = b." + dk;
                    }
                    //var sqlGs = sqlDt + " and xoa = " + (int)TinhTrangXoa.ChuaXoa;
                    var sqlGroup = " group by ";
                    first = true;
                    foreach (var dk in listColumnId)
                    {
                        if (first)
                        {
                            sqlGroup += " a." + dk;
                            first = false;
                        }
                        else
                            sqlGroup += ", a." + dk;
                    }
                    sqlDt += sqlGroup;
                    //sqlGs += sqlGroup;

                    // get data dau tu
                    tableDt = new DataTable();
                    _oracleAdapter = new OracleDataAdapter(sqlDt, _connectDt);
                    _oracleAdapter.Fill(tableDt);

                    // get data giam sat 
                    tableGs = new DataTable();
                    _oracleAdapter = new OracleDataAdapter(sqlDt, _connectGs);
                    _oracleAdapter.Fill(tableGs);

                    // gen list dong bo object tu bang dau tu tra ve
                    var listDt = new List<DongBoObjectLS>();
                    if (tableDt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tableDt.Rows)
                        {
                            var ls = new DongBoObjectLS();
                            var ob = GenObjectDongBo(listColumnId, dr);
                            ls.DongBoObject = ob;
                            ls.LAN = Convert.ToInt64(dr[listColumnId.Count]);
                            listDt.Add(ls);
                        }
                    }

                    // gen list dong bo object tu bang giam sat tra ve
                    var listGs = new List<DongBoObjectLS>();
                    if (tableGs.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tableGs.Rows)
                        {
                            var ls = new DongBoObjectLS();
                            var ob = GenObjectDongBo(listColumnId, dr);
                            ls.DongBoObject = ob;
                            ls.LAN = Convert.ToInt64(dr[listColumnId.Count]);
                            listGs.Add(ls);
                        }
                    }
                    // list id
                    var listDtId = listDt.Select(x => x.DongBoObject).ToList();
                    var listGsId = listGs.Select(x => x.DongBoObject).ToList();

                    // 1. Delete
                    // 1a. select Ids ko ton tai trong DT ma ton tai trong GS
                    //var list1 = listGsId.Except(listDtId).ToList();                    
                    var list1 = new List<DongBoObject>();

                    // todo: can toi uu doan loc nay
                    foreach (var dongBoObject in listGsId)
                    {
                        var t = 0;
                        if (listDtId.Any(boObject => dongBoObject.SO_ID == boObject.SO_ID
                                                     && dongBoObject.MA_DVI == boObject.MA_DVI
                                                     && dongBoObject.MA == boObject.MA
                                                     && dongBoObject.SO_QD == boObject.SO_QD
                                                     && dongBoObject.BT == boObject.BT
                                                     && dongBoObject.HANG == boObject.HANG
                                                     && dongBoObject.MA_HT == boObject.MA_HT
                                                     && dongBoObject.NAM == boObject.NAM
                                                     && dongBoObject.DOT == boObject.DOT
                                                     && dongBoObject.NHA == boObject.NHA))
                        {
                            t = 1;
                        }
                        if (t == 0)
                        {
                            list1.Add(dongBoObject);
                        }
                    }
                    if (list1.Any())
                    {
                        // 1b. danh dau xoa trong GS    
                        foreach (var o in list1)
                        {
                            var sDieuKien = GenStringDieuKien(listColumnId, o);
                            // cap nhat thanh da xoa vao database giam sat 
                            var tempSql = "update " + item + " set xoa = " + (int) TinhTrangXoa.DaXoa + " where ";
                            tempSql += sDieuKien;
                            _lastSql = tempSql;
                            _oracleCommand = new OracleCommand(tempSql, _connectGs);
                            _oracleCommand.CommandType = CommandType.Text;
                            var returnUpdate = _oracleCommand.ExecuteNonQuery();
                            if (returnUpdate == 0) throw new Exception("cap nhat tinh trang xoa that bai");
                        }
                    }

                    // 2. Update
                    // 2a. select Ids co "lan" trong lich su DT > "lan" trong lich su GS    
                    //var list2 = (from oDt in listDt from oGs in listGs where oDt.DongBoObject == oGs.DongBoObject && oDt.LAN > oGs.LAN select oDt).ToList();
                    var list2 = new List<DongBoObjectLS>();
                    // todo: can toi uu doan loc nay
                    foreach (var dongBoObject in listDt)
                    {
                        if (listGs.Any(boObject => dongBoObject.DongBoObject.SO_ID == boObject.DongBoObject.SO_ID
                                                   && dongBoObject.DongBoObject.MA_DVI == boObject.DongBoObject.MA_DVI
                                                   && dongBoObject.DongBoObject.MA == boObject.DongBoObject.MA
                                                   && dongBoObject.DongBoObject.SO_QD == boObject.DongBoObject.SO_QD
                                                   && dongBoObject.DongBoObject.BT == boObject.DongBoObject.BT
                                                   && dongBoObject.DongBoObject.HANG == boObject.DongBoObject.HANG
                                                   && dongBoObject.DongBoObject.MA_HT == boObject.DongBoObject.MA_HT
                                                   && dongBoObject.DongBoObject.NAM == boObject.DongBoObject.NAM
                                                   && dongBoObject.DongBoObject.DOT == boObject.DongBoObject.DOT
                                                   && dongBoObject.DongBoObject.NHA == boObject.DongBoObject.NHA
                                                   && dongBoObject.LAN > boObject.LAN))
                        {
                            list2.Add(dongBoObject);
                        }
                    }

                    if (list2.Any())
                    {
                        // 2b. update GS                         
                        var ps = new PaginationSetting {TotalRecords = list2.Count};
                        for (int i = 0; i < ps.TotalPage; i++)
                        {
                            // update bang chinh
                            foreach (var o in list2)
                            {
                                var tempData = new DataTable();
                                var tempSql = "select * from " + item + " where ";
                                tempSql += GenStringDieuKien(listColumnId, o.DongBoObject);
                                _lastSql = tempSql;
                                _oracleAdapter = new OracleDataAdapter(tempSql, _connectDt);
                                _oracleAdapter.Fill(tempData);
                                if (tempData.Rows.Count > 0)
                                {
                                    UpdateDatatable(listColumnId, item, tempData, _connectGs);
                                }

                                // insert bang lich su     
                                tempData = new DataTable();
                                tempSql = "select * from " + item + "_ls where ";
                                tempSql += GenStringDieuKien(listColumnId, o.DongBoObject) + " and lan = " + o.LAN;
                                _lastSql = tempSql;
                                _oracleAdapter = new OracleDataAdapter(tempSql, _connectDt);
                                _oracleAdapter.Fill(tempData);
                                if (tempData.Rows.Count > 0)
                                {
                                    InsertDatatable(item + "_LS", tempData, _connectGs);
                                }
                            }
                        }
                    }

                    // 3. Insert
                    // 3a. select Ids ton tai trong DT ma ko ton tai trong GS
                    //var list3 = listDtId.Except(listGsId).ToList();
                    var list3 = new List<DongBoObject>();
                    // todo: can toi uu doan loc nay
                    foreach (var dongBoObject in listDtId)
                    {
                        var t = 0;
                        if (listGsId.Any(boObject =>
                                         dongBoObject.SO_ID == boObject.SO_ID
                                         && dongBoObject.MA_DVI == boObject.MA_DVI
                                         && dongBoObject.MA == boObject.MA
                                         && dongBoObject.SO_QD == boObject.SO_QD
                                         && dongBoObject.BT == boObject.BT
                                         && dongBoObject.HANG == boObject.HANG
                                         && dongBoObject.MA_HT == boObject.MA_HT
                                         && dongBoObject.NAM == boObject.NAM
                                         && dongBoObject.DOT == boObject.DOT
                                         && dongBoObject.NHA == boObject.NHA))
                        {
                            t = 1;
                        }
                        if (t == 0)
                        {
                            list3.Add(dongBoObject);
                        }
                    }
                    if (list3.Any())
                    {
                        // 3b. insert GS 
                        foreach (var o in list3)
                        {
                            var tempData = new DataTable();
                            var tempSql = "select * from " + item + " where ";
                            tempSql += GenStringDieuKien(listColumnId, o);
                            _lastSql = tempSql;
                            _oracleAdapter = new OracleDataAdapter(tempSql, _connectDt);
                            _oracleAdapter.Fill(tempData);
                            if (tempData.Rows.Count > 0)
                            {
                                InsertDatatable(item, tempData, _connectGs);
                            }
                        }
                    }
                    lastTableName += "<br /> end: " + item;
                }

                #endregion comment

                #endregion bang co lich su


                #region bang ko co lich su simple key

                #region comment for test BangDauTuKoLichSu

                foreach (var item in Enum.GetNames(typeof (BangDauTuKoLichSu)))
                {
                    lastTableName += "<br />begin " + item;

                    // list cac cot la khoa chinh cua bang
                    listColumnId = new List<string>();
                    listColumnId.Add("MA_DVI");
                    // cac bang ma dung chung
                    if (item.IndexOf("MA", System.StringComparison.Ordinal) != -1)
                    {
                        listColumnId.Add("MA");
                    }
                        // cac bang thong tin
                    else
                    {
                        switch (item)
                        {
                                // cac bang primary key complex

                            case "BDT_QLDT_KHDT_TD":
                                listColumnId.Add("SO_QD");
                                listColumnId.Add("NAM");
                                break;
                            case "BDT_QLDT_GTH_MOI_NHA":
                            case "BDT_QLDT_GTH_MO_NHA":
                            case "BDT_QLDT_GTH_XET_NHA":
                                listColumnId.Add("SO_ID");
                                listColumnId.Add("NHA");
                                break;
                            case "BDT_QLDT_GTH_XET_TBI":
                            case "BDT_QLDT_GTH_TO_CGIA":
                            case "BDT_QLDT_GTH_TBI":
                            case "BDT_QLDT_QTOAN":
                                listColumnId.Add("SO_ID");
                                listColumnId.Add("BT");
                                break;
                            case "BDT_QLDT_HTHANH":
                                listColumnId.Add("SO_ID");
                                listColumnId.Add("HANG");
                                listColumnId.Add("MA_HT");
                                break;

                                // bang simple primary key
                            default:
                                listColumnId.Add("SO_ID");
                                break;
                        }
                    }
                    // sql get list unique cua 1 ban ghi                    
                    var sqlDt = "select ";
                    var first = true;
                    foreach (var dk in listColumnId)
                    {
                        if (first)
                        {
                            sqlDt += dk;
                            first = false;
                        }
                        else
                        {
                            sqlDt += "," + dk;
                        }
                    }
                    sqlDt += " from " + item;
                    //var sqlGs = sqlDt + " where xoa = " + (int)TinhTrangXoa.ChuaXoa;

                    // get data dau tu
                    tableDt = new DataTable();
                    _oracleAdapter = new OracleDataAdapter(sqlDt, _connectDt);
                    _oracleAdapter.Fill(tableDt);

                    // get data giam sat   
                    tableGs = new DataTable();
                    _oracleAdapter = new OracleDataAdapter(sqlDt, _connectGs);
                    _oracleAdapter.Fill(tableGs);

                    // list object key
                    var listDtId = new List<DongBoObject>();
                    if (tableDt.Rows.Count > 0)
                    {
                        // get list dong bo object tu datatable dau tu tra ve
                        listDtId.AddRange(from DataRow dr in tableDt.Rows select GenObjectDongBo(listColumnId, dr));
                    }

                    var listGsId = new List<DongBoObject>();
                    if (tableGs.Rows.Count > 0)
                    {
                        // get list dong bo object tu datatable giam sat tra ve
                        listGsId.AddRange(from DataRow dr in tableGs.Rows select GenObjectDongBo(listColumnId, dr));
                    }

                    // 1. Delete
                    // 1a. select Ids ko ton tai trong DT ma ton tai trong GS
                    //var list1 = listGsId.Except(listDtId).ToList();
                    var list1 = new List<DongBoObject>();
                    // list ton tai trong ca dau tu va giam sat
                    var list2 = new List<DongBoObject>();
                    // todo: can toi uu doan loc nay
                    foreach (var dongBoObject in listGsId)
                    {
                        var t = 0;
                        if (listDtId.Any(boObject => dongBoObject.SO_ID == boObject.SO_ID
                                                     && dongBoObject.MA_DVI == boObject.MA_DVI
                                                     && dongBoObject.MA == boObject.MA
                                                     && dongBoObject.SO_QD == boObject.SO_QD
                                                     && dongBoObject.BT == boObject.BT
                                                     && dongBoObject.HANG == boObject.HANG
                                                     && dongBoObject.MA_HT == boObject.MA_HT
                                                     && dongBoObject.NAM == boObject.NAM
                                                     && dongBoObject.DOT == boObject.DOT
                                                     && dongBoObject.NHA == boObject.NHA))
                        {
                            t = 1;
                            list2.Add(dongBoObject);
                        }
                        if (t == 0)
                        {
                            list1.Add(dongBoObject);
                        }
                    }
                    if (list1.Any())
                    {
                        // 1b. danh dau xoa trong csdl GS                             
                        foreach (var o in list1)
                        {
                            var sDieuKien = GenStringDieuKien(listColumnId, o);
                            // cap nhat thanh da xoa vao database giam sat 
                            var tempSql = "update " + item + " set xoa = " + (int) TinhTrangXoa.DaXoa + " where ";
                            tempSql += sDieuKien;
                            _lastSql = tempSql;
                            _oracleCommand = new OracleCommand(tempSql, _connectGs);
                            _oracleCommand.CommandType = CommandType.Text;
                            var returnUpdate = _oracleCommand.ExecuteNonQuery();
                            if (returnUpdate == 0) throw new Exception("cap nhat tinh trang xoa that bai");
                        }
                    }

                    // 2. Update
                    // 2a. select Ids ton tai trong ca DT va GS                    
                    //var list2 = listDtId.Where(listGsId.Contains).ToList();
                    if (list2.Any())
                    {
                        // 2b. update GS   
                        foreach (var o in list2)
                        {
                            var tempData = new DataTable();
                            var tempSql = "select * from " + item + " where ";
                            tempSql += GenStringDieuKien(listColumnId, o);
                            _lastSql = tempSql;
                            _oracleAdapter = new OracleDataAdapter(tempSql, _connectDt);
                            _oracleAdapter.Fill(tempData);
                            if (tempData.Rows.Count > 0)
                            {
                                UpdateDatatable(listColumnId, item, tempData, _connectGs);
                            }
                        }
                    }

                    // 3. Insert
                    // 3a. select Ids ton tai trong DT ma ko ton tai trong GS
                    //var list3 = listDtId.Except(listGsId).ToList();
                    var list3 = new List<DongBoObject>();
                    // todo: can toi uu doan loc nay
                    foreach (var dongBoObject in listDtId)
                    {
                        var t = 0;
                        if (listGsId.Any(boObject => dongBoObject.SO_ID == boObject.SO_ID
                                                     && dongBoObject.MA_DVI == boObject.MA_DVI
                                                     && dongBoObject.MA == boObject.MA
                                                     && dongBoObject.SO_QD == boObject.SO_QD
                                                     && dongBoObject.BT == boObject.BT
                                                     && dongBoObject.HANG == boObject.HANG
                                                     && dongBoObject.MA_HT == boObject.MA_HT
                                                     && dongBoObject.NAM == boObject.NAM
                                                     && dongBoObject.DOT == boObject.DOT
                                                     && dongBoObject.NHA == boObject.NHA))
                        {
                            t = 1;
                        }
                        if (t == 0)
                        {
                            list3.Add(dongBoObject);
                        }
                    }
                    if (list3.Any())
                    {
                        // 3b. insert GS 
                        foreach (var o in list3)
                        {
                            var tempData = new DataTable();
                            var tempSql = "select * from " + item + " where ";
                            tempSql += GenStringDieuKien(listColumnId, o);
                            _lastSql = tempSql;
                            _oracleAdapter = new OracleDataAdapter(tempSql, _connectDt);
                            _oracleAdapter.Fill(tempData);
                            if (tempData.Rows.Count > 0)
                            {
                                InsertDatatable(item, tempData, _connectGs);
                            }
                        }
                    }
                    lastTableName += "<br /> end: " + item;
                }

                #endregion end comment for test

                #endregion bang ko co lich su

                //todo: commit transaction
                //_oracleTransaction.Commit();
            }
            catch (Exception ex)
            {
                // todo: roll back 
                //_oracleTransaction.Rollback();

                result.ChangeResult = ChangeResult.ThatBai;
                result.Message = _lastSql + "<br />" + lastTableName + "<br />" + ex.Message;
            }
            finally
            {
                // todo: dong tat ca ket noi
                ConnectDB.CloseConnection(_connectDt);
                ConnectDB.CloseConnection(_connectGs);
            }
            return result;
        }

        /// <summary>
        /// convert from data row to object 
        /// </summary>
        /// <param name="listColumnId"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private DongBoObject GenObjectDongBo(List<string> listColumnId, DataRow dr)
        {
            var ob = new DongBoObject();
            if (listColumnId.IndexOf(ColumnKeyName.MA_DVI.ToString("G")) != -1)
                ob.MA_DVI = Convert.ToString(dr[listColumnId.IndexOf(ColumnKeyName.MA_DVI.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.SO_ID.ToString("G")) != -1)
                ob.SO_ID = Convert.ToInt64(dr[listColumnId.IndexOf(ColumnKeyName.SO_ID.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.MA.ToString("G")) != -1)
                ob.MA = Convert.ToString(dr[listColumnId.IndexOf(ColumnKeyName.MA.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.SO_QD.ToString("G")) != -1)
                ob.SO_QD = Convert.ToString(dr[listColumnId.IndexOf(ColumnKeyName.SO_QD.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.BT.ToString("G")) != -1)
                ob.BT = Convert.ToInt64(dr[listColumnId.IndexOf(ColumnKeyName.BT.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.HANG.ToString("G")) != -1)
                ob.HANG = Convert.ToInt64(dr[listColumnId.IndexOf(ColumnKeyName.HANG.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.MA_HT.ToString("G")) != -1)
                ob.MA_HT = Convert.ToString(dr[listColumnId.IndexOf(ColumnKeyName.MA_HT.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.NAM.ToString("G")) != -1)
                ob.NAM = Convert.ToInt64(dr[listColumnId.IndexOf(ColumnKeyName.NAM.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.DOT.ToString("G")) != -1)
                ob.DOT = Convert.ToInt64(dr[listColumnId.IndexOf(ColumnKeyName.DOT.ToString("G"))]);
            if (listColumnId.IndexOf(ColumnKeyName.NHA.ToString("G")) != -1)
                ob.NHA = Convert.ToString(dr[listColumnId.IndexOf(ColumnKeyName.NHA.ToString("G"))]);
            return ob;
        }

        /// <summary>
        /// sinh ra chuoi dieu kien sau where
        /// </summary>
        /// <param name="list">danh sach ten column dung de so sanh</param>
        /// <param name="dongBoObject">value</param>
        /// <returns>chuoi dieu kien</returns>
        private string GenStringDieuKien(List<string> list, DongBoObject dongBoObject)
        {
            var result = "";
            if (list.IndexOf(ColumnKeyName.MA_DVI.ToString("G")) != -1)
                result += " " + ColumnKeyName.MA_DVI.ToString("G") + " = '" + dongBoObject.MA_DVI + "'";
            // cac thao tac voi bag luon can ton tai ma don vi                               
            if (list.IndexOf(ColumnKeyName.SO_ID.ToString("G")) != -1)
                result += " and " + ColumnKeyName.SO_ID.ToString("G") + " = " + dongBoObject.SO_ID;
            if (list.IndexOf(ColumnKeyName.MA.ToString("G")) != -1)
                result += " and " + ColumnKeyName.MA.ToString("G") + " = '" + dongBoObject.MA + "'";
            if (list.IndexOf(ColumnKeyName.SO_QD.ToString("G")) != -1)
                result += " and " + ColumnKeyName.SO_QD.ToString("G") + " = '" + dongBoObject.SO_QD + "'";
            if (list.IndexOf(ColumnKeyName.BT.ToString("G")) != -1)
                result += " and " + ColumnKeyName.BT.ToString("G") + " = " + dongBoObject.BT;
            if (list.IndexOf(ColumnKeyName.HANG.ToString("G")) != -1)
                result += " and " + ColumnKeyName.HANG.ToString("G") + " = " + dongBoObject.HANG;
            if (list.IndexOf(ColumnKeyName.MA_HT.ToString("G")) != -1)
                result += " and " + ColumnKeyName.MA_HT.ToString("G") + " = '" + dongBoObject.MA_HT + "'";
            if (list.IndexOf(ColumnKeyName.NAM.ToString("G")) != -1)
                result += " and " + ColumnKeyName.NAM.ToString("G") + " = " + dongBoObject.NAM;
            if (list.IndexOf(ColumnKeyName.DOT.ToString("G")) != -1)
                result += " and " + ColumnKeyName.DOT.ToString("G") + " = " + dongBoObject.DOT;
            if (list.IndexOf(ColumnKeyName.NHA.ToString("G")) != -1)
                result += " and " + ColumnKeyName.NHA.ToString("G") + " = '" + dongBoObject.NHA + "'";
            return result;
        }

        #endregion

        /// <summary>
        /// insert du lieu vao csdl
        /// </summary>
        /// <param name="tableName">ten bang</param>
        /// <param name="data">du lieu</param>
        /// <param name="connect">connection</param>
        /// <returns>ChangeResultSettings</returns>
        private ChangeResultSettings InsertDatatable(string tableName, DataTable data, OracleConnection connect)
        {
            var returnObject = new ChangeResultSettings();
            var sColumnNames =
                string.Join(",", data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray());
            var totalColumn = data.Columns.Count;
            foreach (DataRow dr in data.Rows)
            {
                var sqlInsert = "insert into " + tableName + "(" + sColumnNames + ") values (";
                for (int i = 0; i < totalColumn; i++)
                {
                    var a = data.Columns[i].DataType;
                    switch (a.Name)
                    {
                        case "String":
                            if (dr.IsNull(i))
                                sqlInsert += "null,";
                            else
                            {
                                sqlInsert += "'" + dr[i].ToString().Replace("'", "''") + "',";
                            }
                            break;
                        case "DateTime":
                            if (dr.IsNull(i))
                                sqlInsert += "null,";
                            else
                                sqlInsert += "to_date('" + dr[i] + "', 'mm/dd/yyyy hh:mi:ss AM'),";
                            break;
                        default:
                            if (dr.IsNull(i))
                                sqlInsert += "null,";
                            else
                                sqlInsert += dr[i] + ",";
                            break;
                    }
                }
                if (sqlInsert.Substring(sqlInsert.Length - 1, 1) == ",")
                    sqlInsert = sqlInsert.Substring(0, sqlInsert.Length - 1);
                sqlInsert += ")";
                _lastSql = sqlInsert;
                _oracleCommand = new OracleCommand(sqlInsert, connect);
                _oracleCommand.CommandType = CommandType.Text;
                var result = _oracleCommand.ExecuteNonQuery();
                // todo: check result
            }

            return returnObject;
        }

        /// <summary>
        /// update datatable to database
        /// </summary>       
        /// <param name="columnIds">list column id primary key</param>
        /// <param name="tableName">ten bang</param>        
        /// <param name="data">du lieu</param>
        /// <param name="connect">connection</param>
        /// <returns>ChangeResultSettings</returns>
        private ChangeResultSettings UpdateDatatable(List<string> columnIds, string tableName, DataTable data,
                                                     OracleConnection connect)
        {
            var returnObject = new ChangeResultSettings();
            var aColumnNames = data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            var totalColumn = data.Columns.Count;
            foreach (DataRow dr in data.Rows)
            {
                var listDieuKien = new List<string>();
                var sqlUpdate = "update " + tableName + " set ";
                for (int i = 0; i < totalColumn; i++)
                {
                    var a = data.Columns[i].DataType;
                    switch (a.Name)
                    {
                        case "String":
                            // column la khoa chinh
                            if (columnIds.Contains(aColumnNames[i]))
                            {
                                if (dr.IsNull(i))
                                    throw new Exception("bang " + tableName + ", khoa chinh " + aColumnNames[i] +
                                                        " null");
                                listDieuKien.Add(aColumnNames[i] + " = '" + dr[i] + "'");
                            }
                                // column khac
                            else
                            {
                                if (dr.IsNull(i))
                                    sqlUpdate += aColumnNames[i] + " = null,";
                                else
                                    sqlUpdate += aColumnNames[i] + " = '" + dr[i].ToString().Replace("'", "''") + "',";
                            }
                            break;
                        case "DateTime":
                            if (columnIds.Contains(aColumnNames[i]))
                            {
                                if (dr.IsNull(i))
                                    throw new Exception("bang " + tableName + ", khoa chinh " + aColumnNames[i] +
                                                        " null");
                                // todo: xem lai chuoi dieu kien trong truong hop nay
                                listDieuKien.Add(aColumnNames[i] + " = to_date('" + dr[i] +
                                                 "', 'mm/dd/yyyy hh:mi:ss AM')");
                            }
                            else
                            {
                                if (dr.IsNull(i))
                                    sqlUpdate += aColumnNames[i] + " = null,";
                                else
                                    sqlUpdate += aColumnNames[i] + " = to_date('" + dr[i] +
                                                 "', 'mm/dd/yyyy hh:mi:ss AM'),";
                            }
                            break;
                        default:
                            if (columnIds.Contains(aColumnNames[i]))
                            {
                                if (dr.IsNull(i))
                                    throw new Exception("bang " + tableName + ", khoa chinh " + aColumnNames[i] +
                                                        " null");
                                listDieuKien.Add(aColumnNames[i] + " = " + dr[i]);
                            }
                            else
                            {
                                if (dr.IsNull(i))
                                    sqlUpdate += aColumnNames[i] + " = null,";
                                else
                                    sqlUpdate += aColumnNames[i] + " = " + dr[i] + ",";
                            }
                            break;
                    }

                }
                sqlUpdate += " xoa = " + (int) TinhTrangXoa.ChuaXoa + " where ";
                var first = true;
                foreach (var dk in listDieuKien)
                {
                    if (first)
                    {
                        sqlUpdate += dk;
                        first = false;
                    }
                    else
                    {
                        sqlUpdate += " and " + dk;
                    }
                }

                _lastSql = sqlUpdate;
                _oracleCommand = new OracleCommand(sqlUpdate, connect);
                _oracleCommand.CommandType = CommandType.Text;
                var result = _oracleCommand.ExecuteNonQuery();
                if (result == 0) returnObject.ChangeResult = ChangeResult.ThatBai;
            }

            return returnObject;
        }
    }
}
