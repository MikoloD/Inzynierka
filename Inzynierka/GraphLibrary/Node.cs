using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GraphLibrary
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
    }
}
