using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using AutoMapper;
using Business.Layer.Interfaces.Processing.Triangle;
using log4net;
using Infrastructure;
using WebMvc.Models.TriangleModel;
using WebMvc.Models;
namespace WebMvc.Controllers
{
    /// <summary>
    /// <see cref="HomeController"/>Controller for application start up and handling triangular action
    /// </summary>
    public class HomeController : Controller
    {
        #region Fields
        /// <summary>
        /// Logger for logging information interface
        /// </summary>
        private readonly ILog _logger;
        /// <summary>
        /// Maps one object to another interface
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Business layer triangle processing interface
        /// </summary>
        private readonly IBLTriangleProcessing _blTriangleProcessing;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logManager">Log  manager interface</param>
        /// <param name="mapper"> Mapping model interface</param>
        /// <param name="blTriangleProcessing">Business layer triangle processing interface</param>
        public HomeController(ILogManager logManager
            , IMapper mapper
            , IBLTriangleProcessing blTriangleProcessing
            )
        {

            _logger = logManager.GetLog(typeof(HomeController)); ;
            _mapper = mapper;
            _blTriangleProcessing = blTriangleProcessing;
        }
        #endregion

        #region Action Methods
        /// <summary>
        /// Index view action method for displaying triangle information<see cref="TriangleModel"/>
        /// </summary>
        /// <returns>Index view </returns>
        public async Task<ActionResult> Index()
        {
            // Model for the view
            TriangleModel model = null;
            // Web service base address
            string baseaddress = WebConfigurationManager.AppSettings["WepApiBaseAddress"];
            // Triangle startup route addess
            string startuparoute = WebConfigurationManager.AppSettings["TraingleStartUpInfoRoute"];
            // Access route start up information
            var result = await _blTriangleProcessing.GetStartInformationAsync(baseaddress, startuparoute);
            if(result != null)
            {
                // Store link information for accessing triangle verticesinformaiton
                ConfigurationManager.AppSettings["TraingleVericesLinkHref"]= result.Links[0].Href;
                ConfigurationManager.AppSettings["TraingleVericesLinkMethod"] = result.Links[0].Method;
                ConfigurationManager.AppSettings["TraingleVericesLinkRel"] = result.Links[0].Rel;
                var smodel=_mapper.Map<TriangleStartupModel>(result);
                // Model for index view
                model = new TriangleModel { TriangleStartupModel = smodel, TriangleVerticesModel = new TriangleVerticesModel() };
             }
            else
            {
                // Create default model for index view
                var smodel = new TriangleStartupModel(new List<string>(), new List<int>(), "~/images/verticechart.png");
                model = new TriangleModel { TriangleStartupModel = smodel, TriangleVerticesModel = new TriangleVerticesModel() };

            }
            return View(model);
        }

        /// <summary>
        /// Return triangle vertices view information<seealso cref="TriangleVerticesModel"/>  based on a given row and column selected
        /// </summary>
        /// <param name="rowSelected">Row selected</param>
        /// <param name="columnSelected">Column selected</param>
        /// <returns></returns>

        [HttpGet]
 
        public async Task<ActionResult> GetVertices( string rowSelected, string columnSelected)
        {
            // Get triangle vertices information
            var results = await  _blTriangleProcessing.GetTriangleVerticesAsync(
                WebConfigurationManager.AppSettings["WepApiBaseAddress"]
                , WebConfigurationManager.AppSettings["TraingleVericesInfoRoute"]
                , rowSelected
                , Convert.ToInt32(columnSelected));
            try
            {
                if(results.Any())
                { 
                    var vertices = results.Select(result => new VerticeModel
                    {
                        X  = Convert.ToInt32(result.XValue * 10.0).ToString(),
                        Y = Convert.ToInt32(result.YValue * 10.0).ToString(),
                    }).ToList();
                    return PartialView("_vertices", new TriangleVerticesModel { Vertices = vertices });
                    
                }

            }
            catch (Exception e)
            {
                _logger.Fatal($"GetVertices Exception{e.Message}",e);
            }

            // Return defualt triangle vertice view information
           return PartialView("_vertices", new TriangleVerticesModel  { Vertices =new List<VerticeModel>()});

        }
        #endregion
    }
}