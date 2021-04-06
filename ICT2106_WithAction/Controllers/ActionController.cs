using ICT2106.Interfaces;
using ICT2106.Models;
using ICT2106.Models.AirTreatment;
using ICT2106.Models.Cameras;
using ICT2106.Models.Lightings;
using ICT2106.Models.Securities;
using ICT2106.Models.Speakers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Controllers
{
    public class ActionController : Controller
    {
        private List<string> allCategory = new CategoryModel().GetAllCategory();
        private ICategoryPropertyType _propertyInterface;
        private IAction _action = new ActionModel();
        private ActionDAO _dao;

        [HttpGet]
        public IActionResult ActionQuickSelect(string category)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            ViewBag.uniquePropertyList = _dao.getActionCategoryFromDB(category);
            ViewData["CATEGORY"] = category;
            return View();
        }

        [HttpGet]
        public IActionResult ActionCategory(ActionModel propertySelect)
        {
            ActionGateway context = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            ViewData["CATEGORYTYPE"] = allCategory;
            if (propertySelect.ACTIONPROPERTYLIST != null)
            {
                List<object> tempViewData = new List<object>();
                tempViewData.Add(context.getAllDevice_Id_Name_FromDB(propertySelect.ACTIONCATEGORY) as List<String>);
                tempViewData.Add(propertySelect);

                ViewData["getAllDevices_Id_Name"] = tempViewData;
                ViewBag.selectedAction = propertySelect;
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ActionCategory(ActionModel model, string categoryList, string actionButtons)
        {
            ActionGateway context = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            if (actionButtons == "Confirm Category")
            {
                switch (categoryList)
                {
                    case "Lighting":
                        _propertyInterface = new LightingModel();
                        break;
                    case "Camera":
                        _propertyInterface = new CameraModel();
                        break;
                    case "Security":
                        _propertyInterface = new SecurityModel();
                        break;
                    case "Speaker":
                        _propertyInterface = new SpeakerModel();
                        break;
                    case "Air Treatment":
                        _propertyInterface = new AirModel();
                        break;
                    case null:
                        throw new NullReferenceException();
                }

                List<string> propertyName = _propertyInterface.getCategoryProperties();
                ViewData["CATEGORYTYPE"] = allCategory;
                ViewData["CATEGORYPROPERTIES"] = propertyName;
                ViewData["SELECTEDCATEGORY"] = categoryList;

                List<object> tempViewData = new List<object>();
                tempViewData.Add(context.getAllDevice_Id_Name_FromDB(categoryList) as List<String>);
                ViewData["getAllDevices_Id_Name"] = tempViewData;
                return View();
            }
            else
            {
                ViewData["CATEGORYTYPE"] = allCategory;
                return View();
            }
        }

        [HttpGet]
        public IActionResult ActionDisplay()
        {
            ActionModel create = _action.getActionInstance();
            TryUpdateModelAsync(create); // This is the asynchronous call to try to take data from the url into the ActionModel variable

            if (create != null)
            {
                ViewData["ACTION"] = create;
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ActionDisplay(ActionModel actionmodel)
        {
            return RedirectToAction("Rules", "Rule", actionmodel);
        }

        [HttpGet]
        public IActionResult ActionMain()
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            ViewBag.getAllActionList = _dao.getAllActionFromDB();
            return View();
        }

        ////UPDATE////

        //Lighting//
        /*
         * @params lightingmodel object with only actionId populated
         * @returns View/Action/ActionLightingEditForm.cshtml
         * This function is to retrieve (CRUD) from DB 
         * and get a single lighting action 
         * and pass to View/ActionLightingEditForm.cshtml
         */
        public IActionResult LightingEditForm(ActionModel lightingActionModelToPassId)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            ActionModel oneLightingActionModel = _dao.getActionFromDB(lightingActionModelToPassId.ACTIONID);
            ViewData["oneLightingActionModel"] = oneLightingActionModel as ActionModel;
            return View();
        }

        /*
         * @params lightingmodel object with name, properties populated
         * @returns View/Home/Index.cshtml
         * This function is to update (CRUD) to DB a single Lighting Action
         * and get number of rows affected hoping to get 1 as a result
         */
        [HttpPost]
        public IActionResult SubmitLightingEditForm(string lightingId, string lightingName, string lightingStatus, string lightingBrightness, string lightingColor, string submitBtn)
        {
            if (submitBtn == "submitLightingEditForm")
            {
                _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
                ActionModel newActionModelObj = _action.getActionInstance();
                newActionModelObj.ACTIONID = int.Parse(lightingId);

                newActionModelObj.ACTIONNAME = lightingName;

                List<String> newActionPropertiesList = new List<String>();
                newActionPropertiesList.Add(lightingStatus);
                newActionPropertiesList.Add(lightingBrightness);
                newActionPropertiesList.Add(lightingColor);
                newActionModelObj.ACTIONPROPERTYLIST = newActionPropertiesList;

                int no_of_affected_rows = _dao.updateAction(newActionModelObj);
            }
            return RedirectToAction("ActionMain", "Action");
        }
        //Lighting//

        //Air//
        /*
         * @params airmodel object with only actionId populated
         * @returns View/Action/ActionAirEditForm.cshtml
         * This function is to retrieve (CRUD) from DB 
         * and get a single air action 
         * and pass to View/ActionAirEditForm.cshtml
         */
        public IActionResult AirEditForm(ActionModel lightingActionModelToPassId)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            ActionModel oneAirActionModel = _dao.getActionFromDB(lightingActionModelToPassId.ACTIONID);
            ViewData["oneAirActionModel"] = oneAirActionModel as ActionModel;
            return View();
        }

        /*
         * @params airgmodel object with name, properties populated
         * @returns View/Home/Index.cshtml
         * This function is to update (CRUD) to DB a single Air Action
         * and get number of rows affected hoping to get 1 as a result
         */
        [HttpPost]
        public IActionResult SubmitAirEditForm(string airId, string airName, string airStatus, string airSpeed, string airPan, string submitBtn)
        {
            if (submitBtn == "submitAirEditForm")
            {
                _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
                ActionModel newActionModelObj = _action.getActionInstance();
                newActionModelObj.ACTIONID = int.Parse(airId);

                newActionModelObj.ACTIONNAME = airName;

                List<String> newActionPropertiesList = new List<String>();
                newActionPropertiesList.Add(airStatus);
                newActionPropertiesList.Add(airSpeed);
                newActionPropertiesList.Add(airPan);
                newActionModelObj.ACTIONPROPERTYLIST = newActionPropertiesList;

                int no_of_affected_rows = _dao.updateAction(newActionModelObj);
            }
            return RedirectToAction("ActionMain", "Action");
        }
        //Air//


        //Security//
        /*
         * @params securitymodel object with only actionId populated
         * @returns View/Action/ActionSecurityEditForm.cshtml
         * This function is to retrieve (CRUD) from DB 
         * and get a single air action 
         * and pass to View/ActionSecurityEditForm.cshtml
         */
        public IActionResult SecurityEditForm(ActionModel securityActionModelToPassId)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            ActionModel oneSecurityActionModel = _dao.getActionFromDB(securityActionModelToPassId.ACTIONID);
            ViewData["oneSecurityActionModel"] = oneSecurityActionModel as ActionModel;
            return View();
        }


        /*
         * @params securitygmodel object with name, properties populated
         * @returns View/Home/Index.cshtml
         * This function is to update (CRUD) to DB a single Security Action
         * and get number of rows affected hoping to get 1 as a result
         */
        [HttpPost]
        public IActionResult SubmitSecurityEditForm(string securityId, string securityName, string securityStatus, string submitBtn)
        {
            if (submitBtn == "submitSecurityEditForm")
            {
                _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
                ActionModel newActionModelObj = _action.getActionInstance();
                newActionModelObj.ACTIONID = int.Parse(securityId);

                newActionModelObj.ACTIONNAME = securityName;

                List<String> newActionPropertiesList = new List<String>();
                newActionPropertiesList.Add(securityStatus);
                newActionModelObj.ACTIONPROPERTYLIST = newActionPropertiesList;

                int no_of_affected_rows = _dao.updateAction(newActionModelObj);
            }
            return RedirectToAction("ActionMain", "Action");
        }
        //Security//

        //Speaker//
        /*
         * @params speakermodel object with only actionId populated
         * @returns View/Action/ActionSecurityEditForm.cshtml
         * This function is to retrieve (CRUD) from DB 
         * and get a single air action 
         * and pass to View/ActionSecurityEditForm.cshtml
         */
        public IActionResult SpeakerEditForm(ActionModel speakerActionModelToPassId)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            ActionModel oneSpeakerActionModel = _dao.getActionFromDB(speakerActionModelToPassId.ACTIONID);
            ViewData["oneSpeakerActionModel"] = oneSpeakerActionModel as ActionModel;
            return View();
        }

        /*
         * @params securitygmodel object with name, properties populated
         * @returns View/Home/Index.cshtml
         * This function is to update (CRUD) to DB a single Security Action
         * and get number of rows affected hoping to get 1 as a result
         */
        [HttpPost]
        public IActionResult SubmitSpeakerEditForm(string speakerId
            , string speakerName
            , string speakerStatus
            , string speakerService
            , string speakerPlaylist
            , string speakerSong
            , string speakerState
            , string speakerVolume
            , string submitBtn)
        {
            if (submitBtn == "submitSpeakerEditForm")
            {
                _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
                ActionModel newActionModelObj = _action.getActionInstance();
                newActionModelObj.ACTIONID = int.Parse(speakerId);
                newActionModelObj.ACTIONNAME = speakerName;
                List<String> newActionPropertiesList = new List<String>();
                newActionPropertiesList.Add(speakerStatus);
                newActionPropertiesList.Add(speakerService);
                newActionPropertiesList.Add(speakerPlaylist);
                newActionPropertiesList.Add(speakerSong);
                newActionPropertiesList.Add(speakerState);
                newActionPropertiesList.Add(speakerVolume);
                newActionModelObj.ACTIONPROPERTYLIST = newActionPropertiesList;

                int no_of_affected_rows = _dao.updateAction(newActionModelObj);
            }
            return RedirectToAction("ActionMain", "Action");
        }
        //Speaker//

        //Camera//
        /*
         * @params cameramodel object with only actionId populated
         * @returns View/Action/ActionCameraEditForm.cshtml
         * This function is to retrieve (CRUD) from DB 
         * and get a single air action 
         * and pass to View/ActionCameraEditForm.cshtml
         */
        public IActionResult CameraEditForm(ActionModel cameraActionModelToPassId)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            ActionModel oneCameraActionModel = _dao.getActionFromDB(cameraActionModelToPassId.ACTIONID);
            ViewData["oneCameraActionModel"] = oneCameraActionModel as ActionModel;
            return View();
        }

        /*
         * @params cameramodel object with name, properties populated
         * @returns View/Home/Index.cshtml
         * This function is to update (CRUD) to DB a single Camera Action
         * and get number of rows affected hoping to get 1 as a result
         */
        [HttpPost]
        public IActionResult SubmitCameraEditForm(string cameraId, string cameraName, string cameraStatus, string cameraRotationStatus, string submitBtn)
        {
            if (submitBtn == "submitCameraEditForm")
            {
                _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
                ActionModel newActionModelObj = _action.getActionInstance();
                newActionModelObj.ACTIONID = int.Parse(cameraId);

                newActionModelObj.ACTIONNAME = cameraName;

                List<String> newActionPropertiesList = new List<String>();
                newActionPropertiesList.Add(cameraStatus);
                newActionPropertiesList.Add(cameraRotationStatus);
                newActionModelObj.ACTIONPROPERTYLIST = newActionPropertiesList;

                int no_of_affected_rows = _dao.updateAction(newActionModelObj);
            }
            return RedirectToAction("ActionMain", "Action");
        }

        ////DELETE////
        public IActionResult DeleteAction(int id)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            int no_of_affected_rows = _dao.deleteActionFromDB(id);
            return RedirectToAction("ActionMain", "Action");
        }
    }
}
