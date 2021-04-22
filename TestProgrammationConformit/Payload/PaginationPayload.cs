using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Payload
{
    public class PaginationPayload
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationPayload()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationPayload(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
