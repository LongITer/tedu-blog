import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, TimeoutError, tap } from 'rxjs';

interface LoginResponse {
  token: string;
  refreshToken: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = '/api/admin/auth';
  private readonly storageKey = 'tedu-blog-auth';

  get isAuthenticated(): boolean {
    return !!this.getSession()?.token;
  }

  login(username: string, password: string, rememberMe: boolean): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.apiUrl, { username, password }).pipe(
      tap((response) => {
        const storage = rememberMe ? localStorage : sessionStorage;
        const otherStorage = rememberMe ? sessionStorage : localStorage;
        otherStorage.removeItem(this.storageKey);
        storage.setItem(this.storageKey, JSON.stringify(response));
      })
    );
  }

  logout(): void {
    localStorage.removeItem(this.storageKey);
    sessionStorage.removeItem(this.storageKey);
  }

  getLoginError(error: unknown): string {
    if (error instanceof TimeoutError) return 'Máy chủ phản hồi quá lâu. Vui lòng kiểm tra kết nối và thử lại.';
    if (error instanceof HttpErrorResponse) {
      if (error.status === 401) return 'Tên đăng nhập hoặc mật khẩu không chính xác.';
      if (error.status === 0 || error.status >= 500) return 'Không thể kết nối đến máy chủ. Vui lòng thử lại sau.';
    }
    return 'Đăng nhập không thành công. Vui lòng thử lại.';
  }

  private getSession(): LoginResponse | null {
    const stored = localStorage.getItem(this.storageKey) ?? sessionStorage.getItem(this.storageKey);
    if (!stored) return null;
    try {
      return JSON.parse(stored) as LoginResponse;
    } catch {
      this.logout();
      return null;
    }
  }
}
