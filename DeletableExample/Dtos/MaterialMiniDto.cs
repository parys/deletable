using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletableExample
{
    public class MaterialMiniDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        //   public bool CanCommentary { get; set; }

        public bool Pending { get; set; }

        public DateTime AdditionTime { get; set; }

        public int CommentsCount { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        //   [AllowHtml]
        public string Brief { get; set; }

        public int Reads { get; set; }

        //     public string Source { get; set; }

        public string PhotoPath { get; set; }

        //   public DateTime LastModified { get; set; }
    }
}
