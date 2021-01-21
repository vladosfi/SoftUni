import { createAction, props } from '@ngrx/store';
import { IPost, ITheme } from '../../shared/interfaces'

const themeDetailNamespace = `[THEME DETAIL]`;
export const themeDetailSetTheme = createAction(`${themeDetailNamespace} Set Theme`, props<{ theme: ITheme<any> }>());
export const themeDetailSetIsLoading = createAction(`${themeDetailNamespace} Set Is Loading`, props<{ isLoading: boolean }>());
export const themeDetailClear = createAction(`${themeDetailNamespace} Clear`);

const themeListNamespace = `[THEME LIST]`;
export const themeListSetThemeList = createAction(`${themeListNamespace} Set Theme List`, props<{ themeList: ITheme[] }>());
export const themeListLoadThemeList = createAction(`${themeListNamespace} Load Theme List`);
export const themeListLoadThemeListError = createAction(`${themeListNamespace} Load Theme List Error`, props<{ error: string }>());

export const themeListSetPostList = createAction(`${themeListNamespace} Set Post List`, props<{ postList: IPost[] }>());
export const themeListLoadPostList = createAction(`${themeListNamespace} Load Post List`);
export const themeListLoadPostListError = createAction(`${themeListNamespace} Load Post List Error`, props<{ error: string }>());


export const themeListSetIsLoading = createAction(`${themeListNamespace} Set Is Loading`, props<{ isLoading: boolean }>());
export const themeListClear = createAction(`${themeListNamespace} Clear`);
