//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Slides. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Slides;
using System.Drawing;
using Aspose.Slides.Export;

namespace FontFamily
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate Presentation Class
            using (Presentation pres = new Presentation())
            {

                //Get first slide
                ISlide sld = pres.Slides[0];

                //Add an AutoShape of Rectangle type
                IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

                //Remove any fill style associated with the AutoShape
                ashp.FillFormat.FillType = FillType.NoFill;

                //Access the TextFrame associated with the AutoShape
                ITextFrame tf = ashp.TextFrame;
                tf.Text = "Aspose TextBox";

                //Access the Portion associated with the TextFrame
                IPortion port = tf.Paragraphs[0].Portions[0];

                //Set the Font for the Portion
                port.PortionFormat.LatinFont = new FontData("Times New Roman");

                //Set Bold property of the Font
                port.PortionFormat.FontBold = NullableBool.True;

                //Set Italic property of the Font
                port.PortionFormat.FontItalic = NullableBool.True;

                //Set Underline property of the Font
                port.PortionFormat.FontUnderline = TextUnderlineType.Single;

                //Set the Height of the Font
                port.PortionFormat.FontHeight = 25;

                //Set the color of the Font
                port.PortionFormat.FillFormat.FillType = FillType.Solid;
                port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                //Write the presentation to disk
                pres.Save(dataDir + "pptxFont.pptx", SaveFormat.Pptx);
            }

        }
    }
}