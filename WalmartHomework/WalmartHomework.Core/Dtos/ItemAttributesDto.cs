using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartHomework.Core.Dtos
{
    public class ItemAttributesDto
    {
        public string Color { get; set; }
        public string ProductUrlText { get; set; }
        public string Size { get; set; }
        public string ActualColor { get; set; }
        public string CanonicalUrl { get; set; }
        public string ReplenType { get; set; }
        public string IsOrderable { get; set; }
        public string WklyFcstWeeks { get; set; }
    }
}
