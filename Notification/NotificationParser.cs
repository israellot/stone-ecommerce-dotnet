using GatewayApiClient.Notification.Contracts;
using GatewayApiClient.Serialization;

namespace GatewayApiClient.Notification {

    public class NotificationParser {

        /// <summary>
        /// Parses a xml into a StatusNotification object.
        /// </summary>
        /// <param name="notificationXml"></param>
        /// <returns></returns>
        public StatusNotification ParseNotification(string notificationXml) {

            // Gets a xml serializer.
            ISerializer serializer = SerializerFactory.Create("xml");

            // Parses the xml into a StatusNotification object.
            StatusNotification statusNotification = serializer.DeserializeObject<StatusNotification>(notificationXml);

            return statusNotification;
        }
    }
}
