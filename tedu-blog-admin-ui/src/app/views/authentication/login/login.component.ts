import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { finalize, timeout } from 'rxjs';
import {
  ButtonDirective,
  CardBodyComponent,
  CardComponent,
  ColComponent,
  ContainerComponent,
  FormCheckComponent,
  FormCheckInputDirective,
  FormCheckLabelDirective,
  FormControlDirective,
  FormDirective,
  FormLabelDirective,
  InputGroupComponent,
  InputGroupTextDirective,
  RowComponent,
  RowDirective,
} from '@coreui/angular';
import { IconDirective } from '@coreui/icons-angular';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  host: {
    class: 'bg-body-tertiary min-vh-100 d-flex flex-row align-items-center'
  },
  imports: [
    ButtonDirective,
    CardBodyComponent,
    CardComponent,
    ColComponent,
    ContainerComponent,
    FormCheckComponent,
    FormCheckInputDirective,
    FormCheckLabelDirective,
    FormControlDirective,
    FormDirective,
    FormLabelDirective,
    FormsModule,
    IconDirective,
    InputGroupComponent,
    InputGroupTextDirective,
    RowComponent,
    RowDirective
  ]
})
export class LoginComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  readonly isSubmitting = signal(false);
  readonly showPassword = signal(false);
  readonly errorMessage = signal('');

  onSubmit(form: NgForm): void {
    if (form.invalid || this.isSubmitting()) {
      form.control.markAllAsTouched();
      return;
    }

    const username = String(form.value.username ?? '');
    const password = String(form.value.password ?? '');
    const rememberMe = Boolean(form.value.rememberMe);
    this.isSubmitting.set(true);
    this.errorMessage.set('');
    this.authService.login(username, password, rememberMe).pipe(
      timeout({ first: 15000 }),
      finalize(() => this.isSubmitting.set(false))
    ).subscribe({
      next: () => {
        const returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
        this.router.navigateByUrl(returnUrl?.startsWith('/') ? returnUrl : '/dashboard');
      },
      error: (error: unknown) => {
        this.errorMessage.set(this.authService.getLoginError(error));
      }
    });
  }
}
