using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    class Student : User
    {
        private int borrowLimit = 3;

        public Student(string name)
            : base(name, "Student")
        {
        }

        public void setBorrowLimit(int borrowLimit)
        {
            this.borrowLimit = borrowLimit;
        }

        public int getBorrowLimit()
        {
            return borrowLimit;
        }
    }

    }
