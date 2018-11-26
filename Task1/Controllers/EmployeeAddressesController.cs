using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task1.Data;

namespace Task1.Controllers
{
    public class EmployeeAddressesController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: EmployeeAddresses
        public async Task<ActionResult> Index()
        {
            return View(await db.EmployeeAddresses.ToListAsync());
        }

        // GET: EmployeeAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAddress employeeAddress = await db.EmployeeAddresses.FindAsync(id);
            if (employeeAddress == null)
            {
                return HttpNotFound();
            }
            return View(employeeAddress);
        }

        // GET: EmployeeAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AddressId,Address1,Address2,City,PostalCode")] EmployeeAddress employeeAddress)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAddresses.Add(employeeAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeeAddress);
        }

        // GET: EmployeeAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAddress employeeAddress = await db.EmployeeAddresses.FindAsync(id);
            if (employeeAddress == null)
            {
                return HttpNotFound();
            }
            return View(employeeAddress);
        }

        // POST: EmployeeAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AddressId,Address1,Address2,City,PostalCode")] EmployeeAddress employeeAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeAddress);
        }

        // GET: EmployeeAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAddress employeeAddress = await db.EmployeeAddresses.FindAsync(id);
            if (employeeAddress == null)
            {
                return HttpNotFound();
            }
            return View(employeeAddress);
        }

        // POST: EmployeeAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeAddress employeeAddress = await db.EmployeeAddresses.FindAsync(id);
            db.EmployeeAddresses.Remove(employeeAddress);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
