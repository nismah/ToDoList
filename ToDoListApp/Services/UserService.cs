using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using ToDoListApp.Data;
using ToDoListApp.Data.Context;

namespace ToDoListApp.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IList<MemberViewModel> GetAllMembers(int userId)
        {
            IList<MemberViewModel> members = new List<MemberViewModel>();

            using (var context = new ToDoListDbContext())
            {
                var user = context.Members.Where(x => x.Id == userId).Include(y => y.Role).FirstOrDefault();

                if (user != null && user.Role.EmployeeRole.Equals("Member", StringComparison.InvariantCultureIgnoreCase))
                {
                    var memberViewModel = _mapper.Map<MemberViewModel>(user);

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://api.quotable.io");
                        var responseTask = client.GetAsync("random");
                        responseTask.Wait();

                        //To store result of web api response.   
                        var result = responseTask.Result;

                        //If success received   
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            memberViewModel.FavouriteQuote = JsonConvert.DeserializeObject<FavouriteQuote>(readTask.Result);
                        }
                    }

                    members.Add(memberViewModel);
                }
                else
                {
                    var allMembers = context.Members.ToList();

                    if (allMembers != null)
                    {
                        foreach (var memeber in allMembers)
                        {
                            var memberViewModel = _mapper.Map<MemberViewModel>(memeber);

                            using (var client = new HttpClient())
                            {
                                client.BaseAddress = new Uri("https://api.quotable.io");
                                var responseTask = client.GetAsync("random");
                                responseTask.Wait();

                                //To store result of web api response.   
                                var result = responseTask.Result;

                                //If success received   
                                if (result.IsSuccessStatusCode)
                                {
                                    var readTask = result.Content.ReadAsStringAsync();
                                    readTask.Wait();
                                    memberViewModel.FavouriteQuote = JsonConvert.DeserializeObject<FavouriteQuote>(readTask.Result);
                                }
                            }

                            members.Add(memberViewModel);
                        }
                    }
                }
            }

            return members;          
        }

        public bool AddPermissions(int userId ,string memberEmail)
        {
            using (var context = new ToDoListDbContext())
            {
                var user = context.Members.Where(x => x.Id == userId).Include(y => y.Role).FirstOrDefault();

                if (user != null && user.Role.EmployeeRole.Equals("Manager", StringComparison.InvariantCultureIgnoreCase))
                {
                    var member = context.Members.Where(x => x.Email.Equals(memberEmail)).Include(y => y.Role).FirstOrDefault();
                    member.HasAccess = true;
                    context.SaveChanges();
                }
            }
            return true;
        }

        public bool RemovePermissions(int userId, string memberEmail)
        {
            using (var context = new ToDoListDbContext())
            {
                var user = context.Members.Where(x => x.Id == userId).Include(y => y.Role).FirstOrDefault();

                if (user != null && user.Role.EmployeeRole.Equals("Manager", StringComparison.InvariantCultureIgnoreCase))
                {
                    var member = context.Members.Where(x => x.Email.Equals(memberEmail)).Include(y => y.Role).FirstOrDefault();

                    if (!member.Role.EmployeeRole.Equals("Manager", StringComparison.InvariantCultureIgnoreCase))
                    {
                        member.HasAccess = false;
                        context.SaveChanges();
                    }
                    else
                        return false;
                }
            }

            return true;
        }
    }
}
