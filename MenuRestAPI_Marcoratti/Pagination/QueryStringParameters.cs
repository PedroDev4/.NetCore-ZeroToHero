namespace MenuRestAPI_Marcoratti.Pagination
{
    public class QueryStringParameters {
    
        const int maxPageSize = 50;
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;

        public int PageSize { 

            get {
                return this._pageSize;
            }
            set {
                this._pageSize = (value > maxPageSize) ? maxPageSize : value;
            }

        }
        
    }
}