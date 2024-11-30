using EnumSelectList.Enums;
using EnumSelectList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EnumSelectList.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            var enumGenders = Enum.GetValues(typeof(GenderType));
            //Enum'lar� dizi olarak �ektik.

            List<GenderListModel> genderList = new();

            //int yazmam�z�n sebebi bize enumlar�n int de�erlerini getirmesini istememiz. var yazsayd�k Erkek, Kadin diye getirirdi.
            foreach(int gender in enumGenders)
            {
                genderList.Add(new GenderListModel
                {
                    Id = gender,
                    Definition = Enum.GetName(typeof(GenderType), gender)
                    //Enum'un name'ini �ektik.
                });
            }

            UserCreateModel model = new()
            {
                //Genders = new SelectList(genderList,"Id","Definition")
                Genders = new SelectList(genderList, nameof(GenderListModel.Id), nameof(GenderListModel.Definition))
            };
            //Burada gender'lar� model i�inde tan�mlamay�p Viewbag ile de g�nderebiliriz.

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(UserCreateModel model)
        {
            //Ekleme servisine y�nlendir

            var enumGenders = Enum.GetValues(typeof(GenderType));

            List<GenderListModel> genderList = new();

            foreach (int gender in enumGenders)
            {
                genderList.Add(new GenderListModel
                {
                    Id = gender,
                    Definition = Enum.GetName(typeof(GenderType), gender)
                });
            }

            model.Genders = new SelectList(genderList, nameof(GenderListModel.Id), nameof(GenderListModel.Definition));

            return View(model);
        }

    }
}
