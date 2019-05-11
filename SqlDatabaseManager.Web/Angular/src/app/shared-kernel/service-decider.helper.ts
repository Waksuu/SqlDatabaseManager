import { environment } from '../../environments/environment';

export function serviceDecider(service : object, mockService: object): object {
  const isMockSuitableEnvironment: boolean = !environment.production && environment.mock;
  return isMockSuitableEnvironment ? mockService : service;
}
