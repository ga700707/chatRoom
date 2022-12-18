using System;
using System.Collections.Generic;

#nullable disable

namespace ctest_model.Entities
{
    public partial class ChatLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Text { get; set; }
        public sbyte? UserType { get; set; }
        public DateTime? LogTime { get; set; }
    }
}
