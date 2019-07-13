import { Provider } from '@angular/compiler/src/compiler_facade_interface';

import { environment } from '../../environments/environment';

export function serviceDecider<TProvider extends Provider>(service: TProvider, mockService: TProvider): TProvider {
  const isMockSuitableEnvironment: boolean = !environment.production && environment.mock;

  const serviceProvider: Provider = {
    provide: service,
    useClass: isMockSuitableEnvironment ? mockService : service
  };
  return serviceProvider;
}
