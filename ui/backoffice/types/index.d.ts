export type NavItem = {
  id: number;
  title: string;
  href?: string;
  disabled?: boolean;
  external?: boolean;
  label?: string;
  description?: string;
};

export type SiteConfig = {
  name: string;
  description: string;
  ogImage: string;
  keywords?: string[];
  links: {
    github: string;
  };
  authors?: {
    name: string;
    url: string;
  };
};
