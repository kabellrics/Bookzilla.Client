using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookzilla.Client.Models
{
    public class Album : SynchroEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int SerieId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Order { get; set; }
        public int CurrentPage { get; set; } = 0;
        public string CoverArtPath { get; set; }
        public ReadingStatus ReadingStatus { get; set; } = ReadingStatus.NonLu;
        public SynchroFileStatus SynchroFileStatus { get; set; } = SynchroFileStatus.None;

    }
}
