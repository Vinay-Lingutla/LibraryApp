using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Entities
{
    public class Loan: BaseEntity
    {
        
        public Guid BookId { get; private set; }
        public Guid MemberId { get; private set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; private set; }
        
        public Loan(Guid BookId,Guid MemberId,DateTime BorrowedDate, DateTime ReturnDate) 
        {
          if(BookId == Guid.Empty)
          {
              throw new ArgumentException("BookId cannot be empty.");
          }
            if(MemberId == Guid.Empty)
            {
                throw new ArgumentException("MemberId cannot be empty.");
            }
            if (BorrowedDate > ReturnDate)
            {
                 throw new ArgumentException("BorrowedDate cannot be later than ReturnDate.");
            }
            this.BookId = BookId;
            this.MemberId = MemberId;
            this.BorrowedDate = BorrowedDate;
            this.ReturnDate = ReturnDate;
        }
    }
}
