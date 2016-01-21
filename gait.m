clear all;

anuj1  = importdata('D:\Files\Kinect\BodyBasics-WPF\data\anuj1.txt');
anuj1knee  = importdata('D:\Files\Kinect\BodyBasics-WPF\data\anuj1knee.txt');
count1 = zeros(size(anuj1));
j=1;
for j =1:size(anuj1)
   count1(j) = j;
end
smoothanuj1= smooth(count1,anuj1,0.1,'rloess');
smoothanuj1knee= smooth(count1,anuj1knee,0.1,'rloess');
%subplot(6,1,1);
%plot(smoothanuj1)
%ylim([0 100])
%subplot(6,1,2)
%plot(count1,anuj1);
%data 2
arya1 = importdata('D:\Files\Kinect\BodyBasics-WPF\data\arya3.txt');
arya1knee = importdata('D:\Files\Kinect\BodyBasics-WPF\data\arya3knee.txt');
count2=zeros(size(arya1));
j=1;
for j =1:size(arya1)
   count2(j) = j;
end
smootharya1= smooth(count2,arya1,0.1,'rloess');
smootharya1knee= smooth(count2,arya1knee,0.1,'rloess');
%subplot(6,1,3);
%plot(smootharya1);
%ylim([0 100])
%subplot(6,1,4);
%plot(count2,arya1);
%data3
deeptanu1 = importdata('D:\Files\Kinect\BodyBasics-WPF\data\deeptanu1.txt');
deeptanu1knee = importdata('D:\Files\Kinect\BodyBasics-WPF\data\deeptanu1knee.txt');
count3=zeros(size(deeptanu1));
j=1;
for j =1:size(deeptanu1)
   count3(j) = j;
end
smoothdeeptanu1= smooth(count3,deeptanu1,0.1,'rloess');
smoothdeeptanu1knee= smooth(count3,deeptanu1knee,0.1,'rloess');
%subplot(6,1,5);
%plot(smoothdeeptanu1)
%ylim([0 100])
%subplot(6,1,6)
%plot(deeptanu1)
%plot(anuj3,count3);
input = importdata('D:\Files\Kinect\BodyBasics-WPF\data\input.txt');
inputknee = importdata('D:\Files\Kinect\BodyBasics-WPF\data\inputknee.txt');

count4 = zeros(size(input));
for j =1:size(input)
   count4(j) = j;
end
smoothinput= smooth(count4,input,0.1,'rloess');
smoothinputknee= smooth(count4,inputknee,0.1,'rloess');
w=100;
d1=dtw(smoothanuj1,smoothinput,w);
d1knee=dtw(smoothanuj1knee,smoothinputknee,w);
%fprintf('Distance anuj arya: distance=%f\n',d1);
d2=dtw(smootharya1,smoothinput,w);
d2knee=dtw(smootharya1knee,smoothinputknee,w);
%fprintf('Distance anuj deeptanu: distance=%f\n',d2);
d3=dtw(smoothdeeptanu1,smoothinput,w);
d3knee=dtw(smoothdeeptanu1knee,smoothinputknee,w);
%fprintf('Distance anuj anuj: distance=%f\n',d3);
diff = min([d1+d1knee d2+d2knee d3+d3knee]);
fprintf('Anuj: %f, Arya: %f, Deeptanu: %f\n',d1+d1knee,d2+d2knee,d3+d3knee);
if diff == (d1+d1knee)
    fprintf('Anuj Bansal\n');
elseif diff == (d2+d2knee)
    fprintf('Chandradeo Arya\n');
    
else
    fprintf('Deeptanu\n');
end