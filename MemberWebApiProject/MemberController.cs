using MemberWebApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemberWebApiProject
{
    public class MemberController : ApiController
    {
        MemberDataClassesDataContext db = new MemberDataClassesDataContext();

        public IEnumerable<tblMember>Get()
        {
            return db.tblMembers.ToList().AsEnumerable();
        }

        public HttpResponseMessage Get(int id)
        {
            var memberDetail = (from a in db.tblMembers where a.MemberID == id select a).FirstOrDefault();

            if(memberDetail != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, memberDetail);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid code or member not found");
            }
        }
        
    }
}