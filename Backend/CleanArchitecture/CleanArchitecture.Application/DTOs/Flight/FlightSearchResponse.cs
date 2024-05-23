using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Flight
{
     public class AvailableExtraProduct
    {
        public Configuration configuration { get; set; }
        public string productId { get; set; }
        public string name { get; set; }
        public bool selectedWithTrip { get; set; }
        public SellSpecification sellSpecification { get; set; }
        public string __typename { get; set; }
    }

    public class AvailableSortType
    {
        public string code { get; set; }
        public string name { get; set; }
        public string __typename { get; set; }
    }

    public class Bound
    {
        public string boundId { get; set; }
        public IncludedCabinBaggage includedCabinBaggage { get; set; }
        public IncludedCheckedBaggage includedCheckedBaggage { get; set; }
        public List<Segment> segments { get; set; }
        public string __typename { get; set; }
    }

    public class CarrierPromo
    {
        public decimal? value { get; set; }
        public Currency currency { get; set; }
        public string __typename { get; set; }
    }

    public class CheapTrip
    {
        public decimal? value { get; set; }
        public Currency currency { get; set; }
        public string __typename { get; set; }
    }

    public class Configuration
    {
        public string productPreSelection { get; set; }
        public string __typename { get; set; }
    }

    public class Currency
    {
        public string code { get; set; }
        public string __typename { get; set; }
    }

    public class Data
    {
        public List<object> availableFilters { get; set; }
        public List<AvailableSortType> availableSortTypes { get; set; }
        public List<object> carrierCodes { get; set; }
        public List<object> carrierNames { get; set; }
        public List<Flight> flights { get; set; }
        public decimal? flightsCount { get; set; }
        public decimal? filteredFlightsCount { get; set; }
        public QuickSortPrices quickSortPrices { get; set; }
        public ResultSetMetaData resultSetMetaData { get; set; }
        public List<Route> routes { get; set; }
        public string searchPath { get; set; }
        public List<SponsoredTrip> sponsoredTrips { get; set; }
        public List<Traveler> travelers { get; set; }
        public string type { get; set; }
        public List<object> tripCampaigns { get; set; }
        public bool validWithVoucher { get; set; }
        public string __typename { get; set; }
    }

    public class Destination
    {
        public string code { get; set; }
        public string name { get; set; }
        public string cityCode { get; set; }
        public string cityName { get; set; }
        public string airportCode { get; set; }
        public string airportName { get; set; }
        public string __typename { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string continentCode { get; set; }
        public string continentName { get; set; }
    }

    public class Flight
    {
        public string id { get; set; }
        public string tripId { get; set; }
        public bool isVI { get; set; }
        public IncludedCabinBaggage includedCabinBaggage { get; set; }
        public IncludedCheckedBaggage includedCheckedBaggage { get; set; }
        public List<Bound> bounds { get; set; }
        public object brandedFares { get; set; }
        public List<AvailableExtraProduct> availableExtraProducts { get; set; }
        public List<IncludedExtraProduct> includedExtraProducts { get; set; }
        public string selectionKey { get; set; }
        public string type { get; set; }
        public List<object> tripCharacteristics { get; set; }
        public List<TripTraveler> tripTravelers { get; set; }
        public List<PaymentMethodPrice> paymentMethodPrices { get; set; }
        public List<TravelerPrice> travelerPrices { get; set; }
        public List<TravelerPricesWithoutPaymentDiscount> travelerPricesWithoutPaymentDiscounts { get; set; }
        public List<string> tripTags { get; set; }
        public object systems { get; set; }
        public VoucherAmount voucherAmount { get; set; }
        public string shareableUrl { get; set; }
        public string __typename { get; set; }
    }

    public class IncludedCabinBaggage
    {
        public bool includedPersonalItem { get; set; }
        public Size3d size3d { get; set; }
        public decimal? pieces { get; set; }
        public decimal? weight { get; set; }
        public string weightUnit { get; set; }
        public string __typename { get; set; }
    }

    public class IncludedCheckedBaggage
    {
        public decimal? pieces { get; set; }
        public decimal? weight { get; set; }
        public string weightUnit { get; set; }
        public string __typename { get; set; }
    }

    public class IncludedExtraProduct
    {
        public string id { get; set; }
        public Texts texts { get; set; }
        public string __typename { get; set; }
    }

    public class MarketingCarrier
    {
        public string code { get; set; }
        public string name { get; set; }
        public string __typename { get; set; }
    }

    public class MarketingCarrier2
    {
        public string code { get; set; }
        public string name { get; set; }
        public string __typename { get; set; }
    }

    public class Markup
    {
        public decimal? value { get; set; }
        public string __typename { get; set; }
    }

    public class Meta
    {
        public decimal? currentPage { get; set; }
        public decimal? limit { get; set; }
        public decimal? totalRecords { get; set; }
        public decimal? totalPage { get; set; }
    }

    public class OperatingCarrier
    {
        public string code { get; set; }
        public string name { get; set; }
        public string __typename { get; set; }
    }

    public class Origin
    {
        public string code { get; set; }
        public string name { get; set; }
        public string cityCode { get; set; }
        public string cityName { get; set; }
        public string airportCode { get; set; }
        public string airportName { get; set; }
        public string __typename { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string continentCode { get; set; }
        public string continentName { get; set; }
    }

    public class PaymentMethodPrice
    {
        public string name { get; set; }
        public Price price { get; set; }
        public string type { get; set; }
        public string __typename { get; set; }
    }

    public class Price
    {
        public Price price { get; set; }
        public object markup { get; set; }
        public object vat { get; set; }
        public string __typename { get; set; }
        public decimal? value { get; set; }
        public Currency currency { get; set; }
    }

    public class PriceRange
    {
        public decimal? min { get; set; }
        public decimal? max { get; set; }
        public string __typename { get; set; }
    }

    public class QuickSortPrices
    {
        public CarrierPromo carrierPromo { get; set; }
        public CheapTrip cheapTrip { get; set; }
        public ShortTrip shortTrip { get; set; }
        public Recommendation recommendation { get; set; }
        public string __typename { get; set; }
    }

    public class Recommendation
    {
        public decimal? value { get; set; }
        public Currency currency { get; set; }
        public string __typename { get; set; }
    }

    public class ResultSetMetaData
    {
        public PriceRange priceRange { get; set; }
        public TravelTimeRange travelTimeRange { get; set; }
        public List<MarketingCarrier> marketingCarriers { get; set; }
        public string __typename { get; set; }
    }

    public class FlightSearchResponse
    {
        public Data data { get; set; }
        public Meta meta { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class Route
    {
        public Origin origin { get; set; }
        public Destination destination { get; set; }
        public string departureAt { get; set; }
        public string departureDate { get; set; }
        public object departureTimeOfDay { get; set; }
        public string __typename { get; set; }
    }

    public class Segment
    {
        public string __typename { get; set; }
        public string segmentId { get; set; }
        public string aircraftType { get; set; }
        public string arrivedAt { get; set; }
        public object brandedFareInformation { get; set; }
        public IncludedCabinBaggage includedCabinBaggage { get; set; }
        public IncludedCheckedBaggage includedCheckedBaggage { get; set; }
        public string cabinClassName { get; set; }
        public string departuredAt { get; set; }
        public Destination destination { get; set; }
        public decimal? duration { get; set; }
        public string equipmentCode { get; set; }
        public string flightNumber { get; set; }
        public MarketingCarrier marketingCarrier { get; set; }
        public decimal? numberOfTechnicalStops { get; set; }
        public OperatingCarrier operatingCarrier { get; set; }
        public string operatingInformation { get; set; }
        public Origin origin { get; set; }
        public List<SegmentDetail> segmentDetails { get; set; }
        public List<string> types { get; set; }
    }

    public class SegmentDetail
    {
        public string paxType { get; set; }
        public decimal? numberOfSeatsLeft { get; set; }
        public string __typename { get; set; }
    }

    public class SellPriceBaggage
    {
        public decimal? maxWeight { get; set; }
        public decimal? numberOfUnits { get; set; }
        public string weightUnit { get; set; }
        public Price price { get; set; }
        public string __typename { get; set; }
    }

    public class SellPriceTraveler
    {
        public Price price { get; set; }
        public string __typename { get; set; }
    }

    public class SellSpecification
    {
        public List<SellPriceTraveler> sellPriceTravelers { get; set; }
        public string __typename { get; set; }
        public List<SellPriceBaggage> sellPriceBaggage { get; set; }
    }

    public class ShortTrip
    {
        public decimal? value { get; set; }
        public Currency currency { get; set; }
        public string __typename { get; set; }
    }

    public class Size3d
    {
        public decimal? height { get; set; }
        public decimal? length { get; set; }
        public decimal? width { get; set; }
        public string __typename { get; set; }
    }

    public class SponsoredTrip
    {
        public string id { get; set; }
        public string tripId { get; set; }
        public bool isVI { get; set; }
        public IncludedCabinBaggage includedCabinBaggage { get; set; }
        public IncludedCheckedBaggage includedCheckedBaggage { get; set; }
        public List<Bound> bounds { get; set; }
        public object brandedFares { get; set; }
        public List<AvailableExtraProduct> availableExtraProducts { get; set; }
        public List<IncludedExtraProduct> includedExtraProducts { get; set; }
        public string selectionKey { get; set; }
        public string type { get; set; }
        public List<string> tripCharacteristics { get; set; }
        public List<TripTraveler> tripTravelers { get; set; }
        public List<PaymentMethodPrice> paymentMethodPrices { get; set; }
        public List<TravelerPrice> travelerPrices { get; set; }
        public List<TravelerPricesWithoutPaymentDiscount> travelerPricesWithoutPaymentDiscounts { get; set; }
        public List<string> tripTags { get; set; }
        public object systems { get; set; }
        public VoucherAmount voucherAmount { get; set; }
        public string shareableUrl { get; set; }
        public string __typename { get; set; }
    }

    public class Texts
    {
        public string name { get; set; }
        public object productSummaryAlternativeName { get; set; }
        public object readMoreText { get; set; }
        public object receiptText { get; set; }
        public string salesAbstract { get; set; }
        public string __typename { get; set; }
    }

    public class Traveler
    {
        public string ageType { get; set; }
        public string __typename { get; set; }
    }

    public class TravelerPrice
    {
        public string id { get; set; }
        public Price price { get; set; }
        public List<object> taxesAndFees { get; set; }
        public string travelerId { get; set; }
        public string __typename { get; set; }
    }

    public class TravelerPricesWithoutPaymentDiscount
    {
        public Price price { get; set; }
        public List<object> taxesAndFees { get; set; }
        public string travelerId { get; set; }
        public string __typename { get; set; }
    }

    public class TravelTimeRange
    {
        public decimal? min { get; set; }
        public decimal? max { get; set; }
        public string __typename { get; set; }
    }

    public class TripTraveler
    {
        public string id { get; set; }
        public string ageType { get; set; }
        public string __typename { get; set; }
    }

    public class Vat
    {
        public decimal? value { get; set; }
        public string __typename { get; set; }
    }

    public class VoucherAmount
    {
        public decimal? value { get; set; }
        public string __typename { get; set; }
    }
}
