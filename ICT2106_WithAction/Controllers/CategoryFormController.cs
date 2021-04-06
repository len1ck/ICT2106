using ICT2106.Interfaces;
using ICT2106.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Models.AirTreatment;
using ICT2106.Models.Cameras;
using ICT2106.Models.Lightings;
using ICT2106.Models.Securities;
using ICT2106.Models.Speakers;

namespace ICT2106.Controllers
{
    public class CategoryFormController : Controller
    {
        private ICategoryPropertyType _propertyInterface;
        private ICreateAction _createAction = new ActionModel();

        public IActionResult CreateLighting(string lightingName, string deviceId, string lightingStatus, string lightingBrightness, string lightingColor)
        {
            ActionGateway context = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            int deviceID = int.Parse(deviceId);
            string deviceName = context.getDeviceByID(deviceID);

            if (String.IsNullOrEmpty(lightingBrightness))
            {
                lightingBrightness = "50";
            }
            if (String.IsNullOrEmpty(lightingColor))
            {
                lightingColor = "White";
            }

            _propertyInterface = new LightingModel();
            List<string> propertyName = _propertyInterface.getCategoryProperties();
            List<string> propertyList = new List<string> { lightingStatus, lightingBrightness, lightingColor };


            ICategoryFactory factory = CategorySingleton.GetInstance().GetFactory("Lighting");
            IGeneralValue general = factory.setGeneralValue(-1, lightingName, "Lighting", deviceID, deviceName);
            IPropertyValue property = factory.setPropertyValues(propertyList, propertyName);

            _createAction.createAction(
                general.getActionID(),
                general.getActionName(),
                general.getCategory(),
                property.getPropertyList(),
                property.getPropertyName(),
                general.getDeviceID(),
                general.getDeviceName()
            );

            return RedirectToAction("ActionDisplay", "Action", (ActionModel)_createAction);
        }


        public IActionResult CreateCamera(string cameraName, string deviceId, string cameraStatus, string cameraViewingAngle, string cameraRecordingStatus, string cameraTakeScreenshot)
        {
            ActionGateway context = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            int deviceID = int.Parse(deviceId);
            string deviceName = context.getDeviceByID(deviceID);

            if (String.IsNullOrEmpty(cameraViewingAngle))
            {
                cameraViewingAngle = "180";
            }

            _propertyInterface = new CameraModel();
            List<string> propertyName = _propertyInterface.getCategoryProperties();
            List<string> propertyList = new List<string> { cameraStatus, cameraViewingAngle, cameraRecordingStatus, cameraTakeScreenshot };

            ICategoryFactory factory = CategorySingleton.GetInstance().GetFactory("Camera");
            IGeneralValue general = factory.setGeneralValue(-1, cameraName, "Camera", deviceID, deviceName);
            IPropertyValue property = factory.setPropertyValues(propertyList, propertyName);

            _createAction.createAction(
                general.getActionID(),
                general.getActionName(),
                general.getCategory(),
                property.getPropertyList(),
                property.getPropertyName(),
                general.getDeviceID(),
                general.getDeviceName()
            );

            return RedirectToAction("ActionDisplay", "Action", (ActionModel)_createAction);
        }

        public IActionResult CreateSecurity(string securityName, string deviceId, string securityStatus)
        {
            ActionGateway context = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            int deviceID = int.Parse(deviceId);
            string deviceName = context.getDeviceByID(deviceID);

            _propertyInterface = new SecurityModel();
            List<string> propertyName = _propertyInterface.getCategoryProperties();
            List<string> propertyList = new List<string> { securityStatus };

            ICategoryFactory factory = CategorySingleton.GetInstance().GetFactory("Security");
            IGeneralValue general = factory.setGeneralValue(-1, securityName, "Security", deviceID, deviceName);
            IPropertyValue property = factory.setPropertyValues(propertyList, propertyName);

            _createAction.createAction(
                general.getActionID(),
                general.getActionName(),
                general.getCategory(),
                property.getPropertyList(),
                property.getPropertyName(),
                general.getDeviceID(),
                general.getDeviceName()
            );

            return RedirectToAction("ActionDisplay", "Action", (ActionModel)_createAction);
        }

        public IActionResult CreateSpeaker(string actionName, string deviceId, string speakerStatus, string speakerService, string speakerPlaylist, string speakerSong, string speakerState, string speakerVolume)
        {

            if (String.IsNullOrEmpty(speakerPlaylist))
            {
                speakerPlaylist = "NIL";
            }
            if (String.IsNullOrEmpty(speakerSong))
            {
                speakerSong = "NIL";
            }
            if (String.IsNullOrEmpty(speakerVolume))
            {
                speakerVolume = "50";
            }

            ActionGateway context = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            int deviceID = int.Parse(deviceId);
            string deviceName = context.getDeviceByID(deviceID);

            _propertyInterface = new SpeakerModel();
            List<string> propertyName = _propertyInterface.getCategoryProperties();
            List<string> propertyList = new List<string> { speakerStatus, speakerService, speakerPlaylist, speakerSong, speakerState, speakerVolume };

            ICategoryFactory factory = CategorySingleton.GetInstance().GetFactory("Speaker");
            IGeneralValue general = factory.setGeneralValue(-1, actionName, "Speaker", deviceID, deviceName);
            IPropertyValue property = factory.setPropertyValues(propertyList, propertyName);

            _createAction.createAction(
                general.getActionID(),
                general.getActionName(),
                general.getCategory(),
                property.getPropertyList(),
                property.getPropertyName(),
                general.getDeviceID(),
                general.getDeviceName()
            );

            return RedirectToAction("ActionDisplay", "Action", (ActionModel)_createAction);
        }

        public IActionResult CreateAir(string actionName, string deviceId, string airStatus, string airSpeed, string airPan)
        {
            ActionGateway context = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;

            int deviceID = int.Parse(deviceId);
            string deviceName = context.getDeviceByID(deviceID);

            _propertyInterface = new AirModel();
            List<string> propertyName = _propertyInterface.getCategoryProperties();
            List<string> propertyList = new List<string> { airStatus, airSpeed, airPan };

            ICategoryFactory factory = CategorySingleton.GetInstance().GetFactory("Air Treatment");
            IGeneralValue general = factory.setGeneralValue(-1, actionName, "Air Treatment", deviceID, deviceName);
            IPropertyValue property = factory.setPropertyValues(propertyList, propertyName);

            _createAction.createAction(
                general.getActionID(),
                general.getActionName(),
                general.getCategory(),
                property.getPropertyList(),
                property.getPropertyName(),
                general.getDeviceID(),
                general.getDeviceName()
            );

            return RedirectToAction("ActionDisplay", "Action", (ActionModel)_createAction);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
