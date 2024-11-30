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
            //Enum'larý dizi olarak çektik.

            List<GenderListModel> genderList = new();

            //int yazmamýzýn sebebi bize enumlarýn int deðerlerini getirmesini istememiz. var yazsaydýk Erkek, Kadin diye getirirdi.
            foreach(int gender in enumGenders)
            {
                genderList.Add(new GenderListModel
                {
                    Id = gender,
                    Definition = Enum.GetName(typeof(GenderType), gender)
                    //Enum'un name'ini çektik.
                });
            }

            UserCreateModel model = new()
            {
                //Genders = new SelectList(genderList,"Id","Definition")
                Genders = new SelectList(genderList, nameof(GenderListModel.Id), nameof(GenderListModel.Definition))
            };
            //Burada gender'larý model içinde tanýmlamayýp Viewbag ile de gönderebiliriz.

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(UserCreateModel model)
        {
            //Ekleme servisine yönlendir

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
