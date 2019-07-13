import { DatabaseType } from '../../database/database-type.enum';

export interface Login {
  serverAddress: string;
  login: string;
  password: string;
  databaseType: DatabaseType;
}
