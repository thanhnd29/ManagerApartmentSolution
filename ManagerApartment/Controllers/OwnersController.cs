using ManagerApartment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ManagerApartment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IConfiguration _config;
        public OwnersController(IConfiguration config)
        {
            _config = config;
        }

        private Manager_ApartmentContext _context = new Manager_ApartmentContext();


        // GET: api/Owners
        [HttpGet("getListOwners")]
        public async Task<ActionResult<IEnumerable<Owner>>> GetListOwners()
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            return await _context.Owners.ToListAsync();
        }

        private string? GetCurrentEmail()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                Console.Write(userClaims.Count());

                foreach (var claim in userClaims)
                {
                    Console.WriteLine(claim.ToString());
                }

                return userClaims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            }
            return null;
        }


        // xác thực bởi token, và sẽ lấy body token ra làm dữ diệu 
        [Authorize]
        [HttpGet("Launch")]
        public async Task<ActionResult<Tennant>> Launch()
        {
            var extractedEmail = GetCurrentEmail();

            if (extractedEmail == null) return NotFound("Token hết hạn");

            var result = await _context.Tennants.FirstOrDefaultAsync(row => row.TennantEmail == extractedEmail);

            return Ok(result);
        }
        //GET: api/Owner/:Id
        [HttpGet("getOwnerById")]
        public async Task<ActionResult<Owner>> GetOwnerById(string id)
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            var account = await _context.Owners.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Owner/:Id
        [HttpPut("updateOwnerById")]
        public async Task<IActionResult> PutOwner(string id, Owner owner)
        {
            if (id != owner.OwnerEmail)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST:api/Owner/:Id   
        [HttpPost("createOwnerInformation")]
        public async Task<ActionResult<Owner>> CreateOwnerInformation(Owner owner)
        {

            if (_context.Owners == null)
            {
                return Problem("Entity set Owner  is null.");
            }
            _context.Owners.Add(owner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OwnerExists(owner.OwnerEmail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTennant", new { id = tennant.TennantEmail }, tennant);
        }

        // DELETE: api/Owner/:Id
        [HttpDelete("deleteTennantById")]
        public async Task<IActionResult> DeleteTennantById(string id)
        {
            if (_context.Tennants == null)
            {
                return NotFound();
            }
            var account = await _context.Tennants.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Tennants.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExists(string id)
        {
            return (_context.Owners?.Any(e => e.OwnerEmail == id)).GetValueOrDefault();
        }


        public class SignInBody
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class SignInResponse
        {
            public Account Account { get; set; }
            public string AccessToken { get; set; }
        }

        // tạo ra token dựa trên account
        private string GenerateToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // claim này dựa trên email trong tham số account
            var claims = new List<Claim>
            {
                new Claim("email", account.Email)
            };

            // tạo ra token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                // có thời gian chết, 15 phút
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // cho phép nặc danh, ai cũng có thể gọi vào route này mà không cần jwt
        [AllowAnonymous]
        [HttpPost("SignIn")]
        // dòng Task<ActionResult<Account>> hơi dài, nhưng mà ta chỉ cần để ý tới cái trong cùng, tức là Account
        // hàm này sẽ trả về 1 cái tài khoản
        public async Task<ActionResult<SignInResponse>> SignIn(SignInBody body)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'StarCiContext.Accounts'  is null.");
            }

            //Account là cái bảng Account trong db
            //First Or Default Async là hàm tìm cái đầu tiên trong db, nếu có thì trả về Account, còn nếu không trả về null
            var result = await _context.Accounts.FirstOrDefaultAsync(

                // code trong xanh là cây
                // sẽ kiểm tra mỗi row trong cái bảng Account
                // nếu thuộc tính email của nó == thuộc tính email trong body + thuộc tính password của nó == thuộc tính password trong body
                // thì sẽ trả về cái row đó => LINQ 
                row =>
                row.Email == body.Email && row.Password == body.Password
                //
                );

            if (result != null)
                // trả về mã 200, và với kết quả thành công
                return Ok(new SignInResponse()
                {
                    Account = result,

                    // tạo ra accessToken dựa trên tài khoản
                    AccessToken = GenerateToken(result)
                });

            // trả về mã lỗi 404
            return NotFound("The account is not existed");
        }

    }
}
