import { atom, useAtom } from "jotai";

const sidebarAtom = atom({
  isMinimized: false,
});

export const useSidebar = () => {
  const [sidebarState, setSidebarState] = useAtom(sidebarAtom);
  const toggle = () =>
    setSidebarState((prev) => ({ ...prev, isMinimized: !prev.isMinimized }));

  return { isMinimized: sidebarState.isMinimized, toggle };
};
