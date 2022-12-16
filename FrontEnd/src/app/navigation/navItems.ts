import { IPermissionNavData } from "./permissionNavData.interface";

export const navItems: IPermissionNavData[] = [
  {
    name: 'NAVIGATION.DASHBOARD',
    permission: 'CanReadDashboard',
    url: '/dashboard',
    icon: 'icon-home',
  },
  {
    name: 'NAVIGATION.PATIENTS',
    permission: 'CanReadDashboard',
    url: '/patients',
    icon: 'icon-user',
  },
  {
    name: 'NAVIGATION.ANALYTICS',
    permission: 'CanReadDashboard',
    url: '/analytics',
    icon: 'icon-graph',
  }
  /*,
  {
    title: true,
    name: 'Title'
  },
  {
    name: 'Disabled',
    url: '/dashboard',
    icon: 'icon-ban',
    attributes: { disabled: true },
  },
  {
    name: 'Download CoreUI',
    url: 'http://coreui.io/angular/',
    icon: 'icon-cloud-download',
    class: 'mt-auto',
    variant: 'success',
    attributes: { target: '_blank', rel: 'noopener' }
  },
  {
    name: 'Try CoreUI PRO',
    url: 'http://coreui.io/pro/angular/',
    icon: 'icon-layers',
    variant: 'danger',
    attributes: { target: '_blank', rel: 'noopener' }
  }*/
];
