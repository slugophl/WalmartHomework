using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartHomework.Core.Dtos
{
    public class ItemDto
    {
                public long ItemId { get; set; }
        public long ParentItemId { get; set; }
        public string Name { get; set; }
        public double Msrp { get; set; }
        public double SalePrice { get; set; }
        public string Upc { get; set; }
        public string CategoryPath { get; set; }
        public string CategoryNode { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string BrandName { get; set; }
        public string ThumbnailImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        public string ProductTrackingUrl { get; set; }
        public bool NinetySevenCentShipping { get; set; }
        public double StandardShipRate { get; set; }
        public int TwoThreeDayShippingRate { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public bool Marketplace { get; set; }
        public string SellerInfo { get; set; }
        public bool ShipToStore { get; set; }
        public bool FreeShipToStore { get; set; }
        public string ModelNumber { get; set; }
        public string ProductUrl { get; set; }
        public bool AvailableOnline { get; set; }
        public string Stock { get; set; }
        public string CustomerRating { get; set; }
        public string CustomerRatingImage { get; set; }
        public int NumReviews { get; set; }
        public bool Clearance { get; set; }
        public bool PreOrder { get; set; }
        public DateTime? PreOrderShipsOn { get; set; }
        public string OfferType { get; set; }
        public string Rhid { get; set; }
        public bool Bundle { get; set; }
        public ItemAttributesDto Attributes { get; set; }
        public string AddToCartUrl { get; set; }
        public string AffiliateAddToCartUrl { get; set; }
        public bool FreeShippingOver35Dollars { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public IEnumerable<ImageEntityDto> ImageEntities { get; set; }
        public bool IsTwoDayShippingEligible { get; set; }
        public GiftOptionsDto GiftOptions { get; set; }
    }
}
