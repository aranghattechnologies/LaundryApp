using LaundryApp.Data;
using LaundryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage;

namespace LaundryApp.Services
{
    public class CustomerAccessService : ICustomerAccessService
    {
        private readonly LaundryAppContext context;
        private const string conStr = "BlobEndpoint=https://artdemostorageaccount.blob.core.windows.net/;QueueEndpoint=https://artdemostorageaccount.queue.core.windows.net/;FileEndpoint=https://artdemostorageaccount.file.core.windows.net/;TableEndpoint=https://artdemostorageaccount.table.core.windows.net/;SharedAccessSignature=sv=2022-11-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2024-03-07T17:24:40Z&st=2024-03-07T09:24:40Z&spr=https,http&sig=ZyktjgflwEcvIlfSjwTr1igwpQTLNOcKC1Z4hZ7sySQ%3D";
        private BlobContainerClient containerClient;
        public CustomerAccessService(LaundryAppContext context)
        {
            this.context = context;
            containerClient = new BlobContainerClient(conStr, "profilephotos");
        }

        public List<Claim> SignIn(SignInRequest request)
        {
            var customer = context.Customers.FirstOrDefault(d => d.Email == request.Email 
                                        && d.Password == request.Password);

            if (customer == null)
                throw new AuthenticationException("Login Failed");

            var result = new List<Claim> {
                new Claim("Email",customer.Email),
                new Claim(ClaimTypes.NameIdentifier,customer.Name),
            };

            return result;
        }

        public Customer SignUp(SignUpRequest request)
        {
            //Check if the email is already in use
            if (context.Customers.Any(d => d.Email == request.Email))
                throw new DuplicateEmailException("Email already exist");

            var customer = new Customer();
            customer.Email = request.Email;
            customer.Longitude = 0;
            customer.Latitude = 0;
            customer.Phone = "0";
            customer.Address = "Not Updated";
            customer.CreatedDate = DateTime.UtcNow;
            customer.Name = request.Name;
            customer.Password = request.Password;

            if(request.Photo != null)
            {
                string fileName = Guid.NewGuid() + ".png";
                containerClient.UploadBlob(fileName, request.Photo.OpenReadStream());

                customer.ProfilePicture = "https://artdemostorageaccount.blob.core.windows.net/profilephotos/" + fileName;
                    
            }


            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;

        
        }
    }
}
