using System.Data;

namespace WebApplication1.Models
{
    public class Teacher : User
    {
        public int borrowLimit { get; set; }
        public bool extendBorrow = false;

        public Teacher(string name) : base(name, "Teacher")
        {
            this.borrowLimit = 5;
        }

        public void setExtendBorrow(bool value)
        {
            this.extendBorrow = value;
        }

        public bool getExtendBorrow()
        {
            return extendBorrow;
        }

        public int getBorrowLimit()
        {
            return borrowLimit;
        }

        public void setBorrowLimit(int value)
        {
            this.borrowLimit = value;
        }
    }
}
