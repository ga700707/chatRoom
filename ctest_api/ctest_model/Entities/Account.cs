using System;
using System.Collections.Generic;

#nullable disable

namespace ctest_model.Entities
{
    public partial class Account
    {
        public Account()
        {
            Papers = new HashSet<Paper>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Type { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Token { get; set; }
        public sbyte? Status { get; set; }
        public int? PeopleNumber { get; set; }
        public int? UseNumber { get; set; }
        public int? ExamNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Paper> Papers { get; set; }
    }
}
