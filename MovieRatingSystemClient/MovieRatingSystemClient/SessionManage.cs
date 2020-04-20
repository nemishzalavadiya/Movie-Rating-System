using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRatingSystemClient
{
    public class SessionManage
    {
        public static int sessionId = -1;
        SessionManage(int id) {
            sessionId = id;
        }
        void clearSession() {
            sessionId = -1;
        }
    }
}