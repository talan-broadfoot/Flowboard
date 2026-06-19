import { Component } from '@angular/core';
import { Auth } from '../auth';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  username = '';
  password = '';

  constructor(private auth: Auth, private router: Router) {}
  onLogin () {
    this.auth.login(this.username, this.password).subscribe({
      next: () => this.router.navigate(['/projects']),
      error: () => alert('Login Failed')
    });
  }
}
