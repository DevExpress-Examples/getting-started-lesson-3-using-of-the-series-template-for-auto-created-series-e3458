using System.Windows.Controls;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System;

namespace SilverlightApplication3 {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            chartControl1.DataSource = CreateDataSource();
        }

        List<GSP> CreateDataSource() {

            XDocument document = DataLoader.LoadXmlFromResources("/GSP.xml");
            List<GSP> result = new List<GSP>();
            if (document != null) {
                foreach (XElement element in document.Element("GSPs").Elements()) {
                    string region = element.Element("Region").Value;
                    string year = element.Element("Year").Value;
                    double product = Convert.ToDouble(element.Element("Product").Value, CultureInfo.InvariantCulture);
                    result.Add(new GSP(region, year, product));
                }
            }
            return result;
        }

        public static class DataLoader {
            public static XDocument LoadXmlFromResources(string fileName) {
                try {
                    return XDocument.Load("/SilverlightApplication3;component" + fileName);
                }
                catch {
                    return null;
                }
            }
        }

        public class GSP {
            readonly string region;
            readonly string year;
            readonly double product;

            public string Region { get { return region; } }
            public string Year { get { return year; } }
            public double Product { get { return product; } }

            public GSP(string region, string year, double product) {
                this.region = region;
                this.year = year;
                this.product = product;
            }

        }
    }
}
