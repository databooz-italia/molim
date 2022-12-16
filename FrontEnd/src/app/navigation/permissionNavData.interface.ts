import { INavData } from '@coreui/angular/lib/sidebar/public_api';

export interface IPermissionNavData extends INavData {
  permission: string;
}