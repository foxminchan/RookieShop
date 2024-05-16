import React from "react";

interface Props {
  deadline: Date;
}

function useCountdown({ deadline }: Props) {
  const [timeRemaining, setTimeRemaining] = React.useState({
    days: 0,
    hours: 0,
    minutes: 0,
    seconds: 0,
  });

  React.useEffect(() => {
    const calculateTimeRemaining = () => {
      const now = new Date();
      const timeUntilDeadline = deadline.getTime() - now.getTime();

      if (timeUntilDeadline < 0) {
        setTimeRemaining({
          days: -1,
          hours: -1,
          minutes: -1,
          seconds: -1,
        });
        return;
      }

      const days = Math.floor(timeUntilDeadline / (1000 * 60 * 60 * 24));
      const hours = Math.floor(
        (timeUntilDeadline % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60),
      );
      const minutes = Math.floor(
        (timeUntilDeadline % (1000 * 60 * 60)) / (1000 * 60),
      );
      const seconds = Math.floor((timeUntilDeadline % (1000 * 60)) / 1000);

      setTimeRemaining({ days, hours, minutes, seconds });
    };

    // Call calculateTimeRemaining initially and then every second
    calculateTimeRemaining();
    const interval = setInterval(calculateTimeRemaining, 1000);

    // Clean up the interval when the component unmounts
    return () => clearInterval(interval);
  }, []);

  return {
    timeRemaining,
  };
}

export default useCountdown;
