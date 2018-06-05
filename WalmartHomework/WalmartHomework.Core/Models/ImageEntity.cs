using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartHomework.Core.Models
{
    public class ImageEntity
    {
        public string ThumbnailImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        public string EntityType { get; set; }
    }
}
