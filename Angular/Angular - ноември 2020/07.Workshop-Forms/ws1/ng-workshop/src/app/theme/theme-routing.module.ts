import { Routes, RouterModule } from '@angular/router';
import { DetailComponent } from './detail/detail.component';
import { NewComponent } from './new/new.component';
import { ThemeListComponent } from './theme-list/theme-list.component';
import { ThemeComponent } from './theme/theme.component';

const routes: Routes = [
    {
        path: 'theme',
        pathMatch: 'full',
        component: ThemeComponent
    },
    {
        path: 'theme/new',
        component: NewComponent
    },
    {
        path: 'theme/detail/:id',
        component: DetailComponent
    }
];

export const ThemeRouterModule = RouterModule.forChild(routes);