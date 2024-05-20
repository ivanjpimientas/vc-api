using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCoreVCard.Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("email_two")]
        public string? EmailTwo { get; set; }

        [Column("foto")]
        public string? Foto { get; set; }

        [Column("rol")]
        public string? Rol { get; set; }

        [Column("rol_secondary")]
        public string? RolSecondary { get; set; }

        [Column("nickname")]
        public string? Nickname { get; set; }

        [Column("position")]
        public string? Position { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("contact_whatsapp")]
        public string? UserWhatsApp { get; set; }

        [Column("contact_telegram")]
        public string? UserTelegram { get; set; }

        [Column("contact_mobile")]
        public string? Mobile { get; set; }

        [Column("contact_website")]
        public string? Website { get; set; }

        [Column("about_me")]
        public string? AboutMe { get; set; }

        [Column("about_personal")]
        public string? AboutPersonal { get; set; }

        [Column("about_academy")]
        public string? AboutAcademy { get; set; }

        [Column("about_professional")]
        public string? AboutProfessional { get; set; }

        [Column("contact_location")]
        public string? Location { get; set; }

        [Column("bg_color")]
        public string? BgColor { get; set; }

        [Column("facebook_link")]
        public string? FacebookLink { get; set; }

        [Column("twitter_link")]
        public string? TwitterLink { get; set; }

        [Column("youtube_link")]
        public string? YoutubeLink { get; set; }

        [Column("linkedin_link")]
        public string? LinkedinLink { get; set; }

        [Column("instagram_link")]
        public string? InstagramLink { get; set; }

        [Column("github_link")]
        public string? GithubLink { get; set; }

        [Column("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("remember_token")]
        public string? RemerberToken { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
