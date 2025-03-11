using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public void Seed()
        {
            if (!Animals.Any())
            {
                var animals = new List<Animal>
                {
                    new Animal { Name = "perro", Translation = "dog", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741553043/Gemini_Generated_Image_uqyvptuqyvptuqyv_zwypp3.jpg" },
                    new Animal { Name = "gato", Translation = "cat", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741552398/Gemini_Generated_Image_bg868xbg868xbg86_hqlnkn.jpg" },
                    new Animal { Name = "elefante", Translation = "elephant", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741553240/Gemini_Generated_Image_glk3kbglk3kbglk3_vgwouc.jpg" },
                    new Animal { Name = "león", Translation = "lion", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741553428/Gemini_Generated_Image_kanp92kanp92kanp_didsca.jpg" },
                    new Animal { Name = "tigre", Translation = "tiger", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741553435/Gemini_Generated_Image_r0nhrgr0nhrgr0nh_axxkxk.jpg" },
                    new Animal { Name = "jirafa", Translation = "giraffe", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741554986/Gemini_Generated_Image_1astii1astii1ast_bujiyg.jpg" },
                    new Animal { Name = "oso", Translation = "bear", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559618/Gemini_Generated_Image_bt677dbt677dbt67_n2gx4a.jpg" },
                    new Animal { Name = "lobo", Translation = "wolf", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559616/Gemini_Generated_Image_6s1akz6s1akz6s1a_nfhupw.jpg" },
                    new Animal { Name = "zorro", Translation = "fox", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559616/Gemini_Generated_Image_6a3g6u6a3g6u6a3g_tc0rac.jpg" },
                    new Animal { Name = "conejo", Translation = "rabbit", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559615/Gemini_Generated_Image_togl3ctogl3ctogl_foqoy2.jpg" },
                    new Animal { Name = "cabra", Translation = "goat", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559615/Gemini_Generated_Image_bjxmw9bjxmw9bjxm_maskzw.jpg" },
                    new Animal { Name = "caballo", Translation = "horse", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559614/Gemini_Generated_Image_ro8j1uro8j1uro8j_dawhlr.jpg" },
                    new Animal { Name = "vaca", Translation = "cow", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559613/Gemini_Generated_Image_esxub9esxub9esxu_eemf7o.jpg" },
                    new Animal { Name = "cerdo", Translation = "pig", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559612/Gemini_Generated_Image_mepbmvmepbmvmepb_yskyn4.jpg" },
                    new Animal { Name = "oveja", Translation = "sheep", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559612/Gemini_Generated_Image_xrtp9txrtp9txrtp_hf38vq.jpg" },
                    new Animal { Name = "ratón", Translation = "mouse", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559611/Gemini_Generated_Image_otcwlgotcwlgotcw_gd2eme.jpg" },
                    new Animal { Name = "pato", Translation = "duck", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559611/Gemini_Generated_Image_iw7pexiw7pexiw7p_ev2epp.jpg" },
                    new Animal { Name = "pollo", Translation = "chicken", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559620/Gemini_Generated_Image_w7qjegw7qjegw7qj_no9qzv.jpg" },
                    new Animal { Name = "águila", Translation = "eagle", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559620/Gemini_Generated_Image_wru8riwru8riwru8_stwy04.jpg" },
                    new Animal { Name = "pájaro", Translation = "bird", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559619/Gemini_Generated_Image_1mjkkx1mjkkx1mjk_gdc8pr.jpg" },
                    new Animal { Name = "pingüino", Translation = "penguin", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741559618/Gemini_Generated_Image_7te4fj7te4fj7te4_andfuk.jpg" },
                    new Animal { Name = "delfín", Translation = "dolphin", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741552161/Gemini_Generated_Image_c0x1apc0x1apc0x1_p4gtyp.jpg" },
                    new Animal { Name = "tiburón", Translation = "shark", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741560201/Gemini_Generated_Image_aqcuioaqcuioaqcu_db4zoz.jpg" },
                    new Animal { Name = "ballena", Translation = "whale", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741560200/Gemini_Generated_Image_ripwojripwojripw_dx9fb2.jpg" },
                    new Animal { Name = "tortuga", Translation = "turtle", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741566202/Gemini_Generated_Image_cs17hrcs17hrcs17_tuvcao.jpg" },
                    new Animal { Name = "rana", Translation = "frog", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741566148/Gemini_Generated_Image_5mxk1t5mxk1t5mxk_u8jhrp.jpg" },
                    new Animal { Name = "serpiente", Translation = "snake", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741566249/Gemini_Generated_Image_b8q156b8q156b8q1_bmr8yo.jpg" },
                    new Animal { Name = "lagarto", Translation = "lizard", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741566148/Gemini_Generated_Image_t92zoht92zoht92z_hzmnsm.jpg" },
                    new Animal { Name = "cocodrilo", Translation = "crocodile", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741566147/Gemini_Generated_Image_l239s9l239s9l239_p88lng.jpg" },
                    new Animal { Name = "hipopótamo", Translation = "hippopotamus", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741566150/Gemini_Generated_Image_hhie9mhhie9mhhie_lptxhm.jpg" },
                    new Animal { Name = "rinoceronte", Translation = "rhinoceros", ImageLocation = "https://res.cloudinary.com/dob1ytrrf/image/upload/c_thumb,w_200,g_face/v1741566149/Gemini_Generated_Image_fqsxkjfqsxkjfqsx_wvd5my.jpg" },
                };

                Animals.AddRange(animals);
                SaveChanges();
            }
        }
    }
}
