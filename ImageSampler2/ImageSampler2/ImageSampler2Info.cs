using System;
using System.Drawing;
using Grasshopper.Kernel;


namespace ImageSampler2
{
    public class ImageSampler2Info : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "ImageSampler2";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("0ef6ec40-8e81-4ab0-b701-c9f91e49fd4e");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
