﻿namespace Step4.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Step4.Model;

    public class TicketsController : ApiController
    {
        private static int nextIssueId = 1;
        private static Dictionary<int, Ticket> issues = new Dictionary<int, Ticket>();

        [HttpPost]
        public IHttpActionResult Post(Ticket issue)
        {
            int issueId;

            Console.WriteLine("Ticket accepted: category:" + issue.Category + " severity:" + issue.Severity + " description:" + issue.Description);

            lock (issues)
            {
                issueId = nextIssueId++;
                TicketsController.issues.Add(issueId, issue);
            }

            return this.Ok(issueId.ToString());
        }
    }
}