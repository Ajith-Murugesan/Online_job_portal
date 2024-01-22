import { JwtPayload, jwtDecode } from "jwt-decode";

export class Commonfunctions { 

    decodeJwtToken(token:any):any
    {
      interface DecodedToken extends JwtPayload {
        Email: string;
        Password: string;
      }    
      const decodedToken: DecodedToken = jwtDecode(token);
      const email = decodedToken.Email;
      const password = decodedToken.Password;
     return {
      Email:email,
      Password:password
     }
    }
  }