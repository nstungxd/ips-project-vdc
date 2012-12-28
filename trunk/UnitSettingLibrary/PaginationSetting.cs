using System;

namespace UnitSettingLibrary
{
    public class PaginationSetting
    {
        private long _totalRecords;
        private int _currentPage;
        private int _pageSize;
        private int _init;

        public long TotalPage
        {
            get
            {
                return this.GetTotalPage();
            }
        }

        public int CurrentPage
        {
            get
            {
                return Math.Max((int)Math.Min(_currentPage, TotalPage), 1);
            }
            set
            {
                if (value != _currentPage)
                {
                    _currentPage = value;
                    UpdateRowIndex();
                }
            }
        }

        public long TotalRecords
        {
            get
            {
                return _totalRecords;
            }
            set
            {
                if (value != _totalRecords)
                {
                    _totalRecords = value;
                    UpdateRowIndex();
                }
            }
        }

        public long StartRowIndex
        { get; private set; }

        public long EndRowIndex
        { get; private set; }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                value = Math.Max(value, 5);
                if (value != _pageSize)
                {
                    _pageSize = value;
                    UpdateRowIndex();
                }
            }
        }
        private bool IsInit
        {
            get
            {
                return _init > 0;
            }
        }

        public PaginationSetting()
        {
            BeginInit();
            CurrentPage = 1;
            TotalRecords = 0;
            PageSize = 100;
            EndInit();
            UpdateRowIndex();
        }

        private long GetTotalPage()
        {
            long num = TotalRecords / PageSize;
            if ((TotalRecords % PageSize) == 0)
            {
                return num;
            }
            else
            {
                return num + 1;
            }
        }

        private void BeginInit()
        {
            ++_init;
        }

        private void EndInit()
        {
            _init = Math.Max(--_init, 0);
        }

        private void UpdateRowIndex()
        {
            if (!IsInit)
            {
                EndRowIndex = Math.Min(this.PageSize * this.CurrentPage, this.TotalRecords);
                StartRowIndex = Math.Min(Math.Max(0, this.PageSize * (this.CurrentPage - 1)), EndRowIndex);
            }
        }
    }
}