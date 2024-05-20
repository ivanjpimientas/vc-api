using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCoreVCard.Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? EmailTwo { get; set; }

        public string? Foto { get; set; }

        public string? Rol { get; set; }

        public string? RolSecondary { get; set; }

        public string? Nickname { get; set; }

        public string? Position { get; set; }

        public string? Description { get; set; }

        public string? UserWhatsApp { get; set; }

        public string? UserTelegram { get; set; }

        public string? Mobile { get; set; }

        public string? Website { get; set; }

        public string? AboutMe { get; set; }

        public string? AboutPersonal { get; set; }

        public string? AboutAcademy { get; set; }

        public string? AboutProfessional { get; set; }

        public string? Location { get; set; }

        public string? BgColor { get; set; }

        public string? FacebookLink { get; set; }

        public string? TwitterLink { get; set; }

        public string? YoutubeLink { get; set; }

        public string? LinkedinLink { get; set; }

        public string? InstagramLink { get; set; }

        public string? GithubLink { get; set; }

        public DateTime? EmailVerifiedAt { get; set; }

        public string? Password { get; set; }

        public string? RemerberToken { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
