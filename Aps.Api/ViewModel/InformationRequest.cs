namespace Aps.Api.ViewModel
{
    public record InformationRequest
    {
        public String? Title { get; set; }
        public String? Description { get; set; }
        public String? Local { get; set; }
        public String? Image { get; set; }
    }
}


