using System;
using System.IO;
using GatewayApiClient.TransactionReportFile.Factory;
using GatewayApiClient.TransactionReportFile.Parsers;
using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile {

    public class TransactionReportParser : ITransactionReportParser {

        /// <summary>
        /// Parses the string into a TransactionReport object.
        /// </summary>
        /// <param name="reportContent"></param>
        /// <returns></returns>
        public TransactionReport ParseString(string reportContent) {

            using (MemoryStream memoryStream = new MemoryStream()) {

                // Writes all report content into a memory stream.
                using (StreamWriter streamWriter = new StreamWriter(memoryStream)) {
                    streamWriter.Write(reportContent);

                    streamWriter.Flush();

                    // Resets the memory stream position.
                    memoryStream.Position = 0;

                    // Parses the report.
                    return this.ParseStream(memoryStream);
                }
            }
        }

        /// <summary>
        /// Parses the file into a TransactionReport object.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public TransactionReport ParseFile(string filename) {

            // Opens the file.
            using (FileStream fileStream = new FileStream(filename, FileMode.Open)) {

                // Parses the report.
                return this.ParseStream(fileStream);
            }
        }

        /// <summary>
        /// Parses the stream into a TransactionReport object.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public TransactionReport ParseStream(Stream stream) {

            TransactionReport report = new TransactionReport();

            int lineCount = 0;

            using (StreamReader reader = new StreamReader(stream)) {

                while (reader.EndOfStream == false) {

                    lineCount++;

                    // Reads the line.
                    string line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) { continue; }

                    // Splits the line contents.
                    string[] lineItems = line.Split(new char[] { ',' }, StringSplitOptions.None);

                    // Obtains a parser for the line.
                    IReportItemParser objectParser = ParserFactory.GetParser(lineItems[0]);

                    if (objectParser == null) {
                        throw new InvalidDataException("The selected file has an invalid format or is currupted. Line " + lineCount.ToString());
                    }

                    IReportItem reportItem = null;

                    try {

                        // Parses the report item.
                        reportItem = objectParser.Parse(lineItems);
                    }
                    catch (Exception ex) {
                        throw new InvalidDataException("The selected file has an invalid format or is currupted. Line " + lineCount.ToString(), ex);
                    }

                    // Adds the parsed item to the report.
                    report.Add(reportItem);
                }
            }

            return report;
        }
    }
}
