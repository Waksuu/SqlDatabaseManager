export function apiUrl(...url: string[]): string {
  return "/api/" + url.join("/");
}
