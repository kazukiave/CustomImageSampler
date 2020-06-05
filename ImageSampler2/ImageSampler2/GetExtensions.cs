using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.IO;

namespace ImageSampler2
{
    public class GetExtensions : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GetExtensions class.
        /// </summary>
        public GetExtensions()
          : base("GetExtensions", "Nickname",
              "Description",
              "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("path", "path", "", GH_ParamAccess.item);
            pManager.AddTextParameter("extension", "extension", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("directoies", "dirs", "", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string path = "";
            string extension = "";

            if (!DA.GetData(0, ref path)) return;
            if (!DA.GetData(1, ref extension)) return;

            var dirs = Directory.EnumerateFiles(path, "*." + extension);
            DA.SetDataList(0, dirs);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("0c308606-8b1c-4f91-8460-0ee6702669bf"); }
        }
    }
}