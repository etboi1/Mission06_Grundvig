using System.ComponentModel.DataAnnotations;

namespace Mission06_Grundvig.Models
{
    public enum Rating
    {
        G,
        PG,
        [Display(Name = "PG-13")]
        PG13,
        R,
        [Display(Name = "TV-Y")]
        TVY,
        [Display(Name = "TV-Y7")]
        TVY7,
        [Display(Name = "TV-Y7-FV")]
        TVY7FV,
        [Display(Name = "TV-G")]
        TVG,
        [Display(Name = "TV-PG")]
        TVPG,
        [Display(Name = "TV-14")]
        TV14,
        [Display(Name = "TV-MA")]
        TVMA,
        NR,
        UR
    }
}
