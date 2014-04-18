using Individuella.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuella.Pages.ThreadPages
{
    public partial class Edit11 : System.Web.UI.Page
    {

       

            private Service _service;

            private Service Service
            {
                get { return _service ?? (_service = new Service()); }
            }



            protected void Page_Load(object sender, EventArgs e)
            {

            }



            // The id parameter should match the DataKeyNames value set on the control
            // or be decorated with a value provider attribute, e.g. [QueryString]int id
            public Thread FormView1_GetItem([RouteData]int ID)
            {

                try
                {
                    Service service = new Service();
                    return service.GetThreadByID(ID);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då Tråden skulle Läsas.");
                    return null;
                }
            }

            


            //Uppdaterar en tråd med specifikt ID. Rätt tråd hämtat med "[RoutData]".
            public void FormView1_UpdateItem([RouteData] int ID)
            {
                try
                {
                    var thread = Service.GetThreadByID(ID);

                    //Retuneras ett nullvärde när ID ska hämtas visas felmeddelande.
                    if (thread == null)
                    {
                        ModelState.AddModelError(String.Empty,
                        String.Format("Tråden kunde ej hittas."));
                        return;
                    }

          
                // Skapar en array-lista som jag kommer stoppa in valen från checkbox
                ArrayList tagsId = new ArrayList();
                CheckBoxList cbl = (CheckBoxList)FormView1.FindControl("CheckBoxListTheard");
                foreach (ListItem liRole in cbl.Items)
                {
                    if (liRole.Selected)
                    {
                        // Gör till int och lägger i listan
                        tagsId.Add(int.Parse(liRole.Value));
                    }
                }

                // Kollar om ifall användaren valt något från checkbox
                if (tagsId.Count == 0)
                {
                    ModelState.AddModelError(String.Empty, "Tråden måste ha minst en tagg.");
                }




                    if (TryUpdateModel(thread))
                    {
                        Service.SaveThread(thread);
                        // Rensar alla artikeltyp för artikel
                        Service.DeleteTagtype(thread.ThreadID);


                        // Skickar in både articleID och categoryID för skapa relationsobjektet tills det inte finns 
                        // några fler valda från checkboxen
                        for (int i = 0; i < tagsId.Count; i++)
                        {
                            Service.InsertTagType(thread.ThreadID, (int)tagsId[i]);
                        }

                        // Lägger till ett nytt meddelande i Page extension-metoden för användaren.
                        Page.SetTempData("Msg", "Tråden har uppdaterats.");
                        //Skickar tillbaka användaren från redigeringsläge till Details, med hjälp av rätt tråd ID.
                        Response.RedirectToRoute("ThreadDetails", new { id = thread.ThreadID });
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel har inträffat när tråden skulle uppdateras.");
                }
            }



            // Retunerar alla olika alternativ (Checkboxes) i en lista, så vi får dem synliga för användaren. 
            public IEnumerable<Tagg> CheckBoxListTheard_GetTags()
            {

                //Skapar ett service objekt och anropar ".GetTags" i serviceklassen.
                Service service = new Service();
                return service.GetTags();
            }


            protected void CheckBoxListTheard_DataBound(object sender, EventArgs e)
            {

            var checkBoxList = (CheckBoxList)FormView1.FindControl("CheckBoxListTheard");
            var threadID = int.Parse(RouteData.Values["id"].ToString());
            var tagTypes = Service.GetTagForThread(threadID);

            foreach (var checkBox in checkBoxList.Items.Cast<ListItem>())
            {
                for (int i = 0; i < tagTypes.Count; i++)
                {
                    if (tagTypes[i].TagID.ToString() == checkBox.Value)
                    {
                        checkBox.Selected = true;
                    }
                }
            }
        }
      }

    
}




        


    


    