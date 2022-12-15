using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Models
{
    public class Serie : SynchroEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string CoverArtPath { get; set; }

    }
}
